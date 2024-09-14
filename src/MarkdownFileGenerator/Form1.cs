using System.Configuration;
using System.Text;

namespace CodeContextExport
{
    public partial class Form1 : Form
    {
        private string savePath;
        private string basePath;
        private List<string> ignorePatterns;
        private bool isGenerating = false;

        public Form1()
        {
            InitializeComponent();

            // Remove any existing event handlers
            treeViewFiles.AfterCheck -= treeViewFiles_AfterCheck;
            this.Load -= Form1_Load;
            btnSetBasePath.Click -= btnSetBasePath_Click;
            btnSetSavePath.Click -= btnSetSavePath_Click;
            btnGenerate.Click -= btnGenerate_Click;

            // Add event handlers
            treeViewFiles.AfterCheck += treeViewFiles_AfterCheck;
            this.Load += Form1_Load;
            btnSetBasePath.Click += btnSetBasePath_Click;
            btnSetSavePath.Click += btnSetSavePath_Click;
            btnGenerate.Click += btnGenerate_Click;

            // Load ignore patterns
            ignorePatterns = File.ReadAllLines("ignorefiles.txt").ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeViewFiles.CheckBoxes = true;

            // Load saved paths
            basePath = ConfigurationManager.AppSettings["BasePath"] ?? string.Empty;
            savePath = ConfigurationManager.AppSettings["SavePath"] ?? string.Empty;

            txtBasePath.Text = basePath;
            txtSavePath.Text = savePath;

            if (!string.IsNullOrEmpty(basePath))
            {
                LoadDirectory(basePath);
            }
        }

        private void btnSetBasePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the base path for your project";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    basePath = folderDialog.SelectedPath;
                    txtBasePath.Text = basePath;
                    SaveSetting("BasePath", basePath);
                    LoadDirectory(basePath);
                }
            }
        }

        private void btnSetSavePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select the save path for generated files";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = folderDialog.SelectedPath;
                    txtSavePath.Text = savePath;
                    SaveSetting("SavePath", savePath);
                }
            }
        }

        private void SaveSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void LoadDirectory(string dir)
        {
            treeViewFiles.Nodes.Clear();

            DirectoryInfo di = new DirectoryInfo(dir);
            TreeNode rootNode = new TreeNode(di.Name)
            {
                Tag = di.FullName,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            treeViewFiles.Nodes.Add(rootNode);

            LoadSubDirectories(dir, rootNode);
            LoadFiles(dir, rootNode);

            rootNode.Expand();
        }

        private void LoadSubDirectories(string dir, TreeNode node)
        {
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo di = new DirectoryInfo(subdirectory);
                TreeNode subNode = new TreeNode(di.Name)
                {
                    Tag = di.FullName,
                    ImageIndex = 0,
                    SelectedImageIndex = 0
                };

                if (ShouldIgnore(di.FullName))
                {
                    subNode.ForeColor = System.Drawing.Color.Gray;
                }

                node.Nodes.Add(subNode);

                LoadSubDirectories(subdirectory, subNode);
                LoadFiles(subdirectory, subNode);
            }
        }

        private void LoadFiles(string dir, TreeNode node)
        {
            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                TreeNode fileNode = new TreeNode(fi.Name)
                {
                    Tag = fi.FullName,
                    ImageIndex = 1,
                    SelectedImageIndex = 1
                };

                if (ShouldIgnore(fi.FullName))
                {
                    fileNode.ForeColor = System.Drawing.Color.Gray;
                }

                node.Nodes.Add(fileNode);
            }
        }
        private bool ShouldIgnore(string path)
        {
            string relativePath = Path.GetRelativePath(basePath, path);
            string[] pathParts = relativePath.Split(Path.DirectorySeparatorChar);

            foreach (string pattern in ignorePatterns)
            {
                if (string.IsNullOrWhiteSpace(pattern) || pattern.StartsWith("#"))
                    continue;

                bool isNegation = pattern.StartsWith("!");
                string actualPattern = isNegation ? pattern.Substring(1) : pattern;

                if (IsMatch(pathParts, actualPattern))
                {
                    return !isNegation;
                }
            }

            return false;
        }

        private bool IsMatch(string[] pathParts, string pattern)
        {
            string[] patternParts = pattern.Split('/');
            int patternIndex = 0;
            int pathIndex = 0;

            while (patternIndex < patternParts.Length && pathIndex < pathParts.Length)
            {
                if (patternParts[patternIndex] == "**")
                {
                    patternIndex++;
                    if (patternIndex == patternParts.Length)
                        return true;

                    while (pathIndex < pathParts.Length)
                    {
                        if (IsMatch(pathParts.Skip(pathIndex).ToArray(), string.Join("/", patternParts.Skip(patternIndex))))
                            return true;
                        pathIndex++;
                    }
                    return false;
                }
                else if (!MatchesPattern(pathParts[pathIndex], patternParts[patternIndex]))
                {
                    return false;
                }

                patternIndex++;
                pathIndex++;
            }

            return patternIndex == patternParts.Length && pathIndex == pathParts.Length;
        }

        private bool MatchesPattern(string input, string pattern)
        {
            if (pattern == "*")
                return true;

            return input.Equals(pattern, StringComparison.OrdinalIgnoreCase);
        }

        private void treeViewFiles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            treeViewFiles.AfterCheck -= treeViewFiles_AfterCheck;
            if (!ShouldIgnore(e.Node.Text))
            {
                CheckAllNodes(e.Node, e.Node.Checked);
            }
            else
            {
                e.Node.Checked = false;
            }
            treeViewFiles.AfterCheck += treeViewFiles_AfterCheck;
        }

        private void CheckAllNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                if (!ShouldIgnore(node.Text))
                {
                    node.Checked = nodeChecked;
                    CheckAllNodes(node, nodeChecked);
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (isGenerating) return;

            isGenerating = true;

            try
            {
                if (string.IsNullOrEmpty(savePath))
                {
                    MessageBox.Show("Please set a save path first.");
                    return;
                }

                var selectedFiles = new List<string>();
                GetCheckedFiles(treeViewFiles.Nodes, selectedFiles);

                if (selectedFiles.Count == 0)
                {
                    MessageBox.Show("No files selected.");
                    return;
                }

                string markdownContent = GenerateMarkdownContent(selectedFiles);

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = $"generated_{timestamp}.txt";
                string filePath = Path.Combine(savePath, fileName);

                File.WriteAllText(filePath, markdownContent);

                DialogResult result = MessageBox.Show(
                    $"File generated successfully: {filePath}\n\nDo you want to open the file?",
                    "Generation Complete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                isGenerating = false;
            }
        }

        private void GetCheckedFiles(TreeNodeCollection nodes, List<string> files)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked && File.Exists(node.Tag.ToString()))
                {
                    files.Add(node.Tag.ToString());
                }
                if (node.Nodes.Count > 0)
                {
                    GetCheckedFiles(node.Nodes, files);
                }
            }
        }

        private string GenerateMarkdownContent(List<string> files)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string file in files)
            {
                sb.AppendLine($"## {file}");
                sb.AppendLine();
                sb.AppendLine("```");
                sb.AppendLine(File.ReadAllText(file));
                sb.AppendLine("```");
                sb.AppendLine();
                sb.AppendLine("---");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}