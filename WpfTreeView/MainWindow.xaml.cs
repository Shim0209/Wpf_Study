using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Path = System.IO.Path;

namespace WpfTreeView
{
    /// <summary>
    /// Interation logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Defualt constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region On Loaded

        /// <summary>
        /// When the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get 컴퓨터의 모든 로직 드라이브
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // Create 각 드라이브 아이템
                var item = new TreeViewItem()
                {
                    // Set the header and path
                    Header = drive,

                    // And the full path
                    Tag = drive
                };

                // Add 더미
                item.Items.Add(null);

                // Listen out 아이템 확장
                item.Expanded += Folder_Expanded;

                // Add 메인 TreeView
                FolderView.Items.Add(item);
            }
        }

        #endregion

        #region Folder Expanded

        /// <summary>
        /// When a folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks
            // 보낸 드라이브 데이터 얻기
            var item = (TreeViewItem)sender;

            // If the item only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            // Clear 더미
            item.Items.Clear();

            // Get full path
            var fullPath = (string)item.Tag;
            #endregion

            #region Get Folders
            // Create a blank list for directories
            var directories = new List<string>();

            // 폴더로부터 디렉터리 가져오기
            // ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch { }

            // For each directory
            directories.ForEach(diretoryPath =>
            {
                // Create 각 폴더 아이템
                var subItem = new TreeViewItem()
                {
                    // Set header as folder name
                    //Header = Path.GetFileName(diretoryPath),
                    Header = GetFileFolderName(diretoryPath),
                    // And tag as full path
                    Tag = diretoryPath
                };

                // Add dummy item so we can expand folder
                subItem.Items.Add(null);

                // Handle expanding
                subItem.Expanded += Folder_Expanded;

                // Add this item to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files

            // Create a blank list for files
            var files = new List<string>();

            // 폴더로부터 파일 가져오기
            // ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                {
                    files.AddRange(fs);
                }
            }
            catch { }

            // For each file
            files.ForEach(filePath =>
            {
                // Create 각 파일 아이템
                var subItem = new TreeViewItem()
                {
                    // Set header as file name
                    // Header = Path.GetFileName(filePath),
                    Header = GetFileFolderName(filePath),
                    // And tag as full path
                    Tag = filePath
                };

                // Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion
        }


        #endregion

        #region Helpers
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // C:\Something\a folder
            // C:\Something\a file.png
            // a file file.png

            // If we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            // Find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // Return the name after last backslash
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
