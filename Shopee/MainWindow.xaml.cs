using EAGetMail;
using KAutoHelper;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Shopee.MainWindow;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Windows.Media.Animation;

using System.Net.Http.Headers;
using RestSharp;
using System.Web;
using xNet;
using System.Drawing;
using Newtonsoft.Json.Linq;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace Shopee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public ObservableCollection<FileItem> FileItems { get; set; }
        private ObservableCollection<DeviceInfo> deviceInfos = new ObservableCollection<DeviceInfo>();
        private FileViewModel _viewModel;
        public MainWindow()
        {
        
            InitializeComponent();
            dataGridTab1.ItemsSource = deviceInfos;
            _viewModel = new FileViewModel();
            DataContext = _viewModel;


        }
        private readonly object _lockObject = new object();
        public static List<string> GetDevicesRecovery()
        {
            List<string> list = new List<string>();
            string input = KAutoHelper.ADBHelper.ExecuteCMD("adb devices");
            string pattern = "(?<=List of devices attached)([^\\n]*\\n+)+";
            MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.Singleline);
            if (matchCollection.Count > 0)
            {
                string value = matchCollection[0].Groups[0].Value;
                string[] array = Regex.Split(value, "\r\n");
                string[] array2 = array;
                foreach (string text in array2)
                {
                    if (string.IsNullOrEmpty(text) || !(text != " "))
                    {
                        continue;
                    }

                    string[] array3 = text.Trim().Split('\t');
                    string text2 = array3[0];
                    string text3 = "";
                    try
                    {
                        text3 = array3[1];
                        if (text3 != "recovery" && text3 != "sideload")
                        {
                            continue;
                        }
                    }
                    catch
                    {
                    }

                    list.Add(text2.Trim());
                }
            }

            return list;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<String> Devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var item in Devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    try
                    {
                        while (true) 
                        {
                            // ChayCodeApi chaycode = new ChayCodeApi("c4a20cb7c1a704dd");

                            //UpdateDeviceStatus(p.deviceID, "Đang skip setup google");
                           
                            //Viotp viotp = new Viotp("c06acd2f33f642f48ebf423dfe618723");
                            //string sdt;

                            //do
                            //{

                            //    sdt = viotp.GetSDT();
                            //    //sdt = chaycode.GetSDT();
                            //    if (p.checkexist(sdt))
                            //    {
                            //      // chaycode.Cancel();
                            //    }
                            //    else
                            //    {


                            //        break;
                            //    }
                            //}
                            //while (true);

                            //Clipboard.SetText(sdt);
                            //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell settings put system screen_off_timeout 2147483647");
                            //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell settings put system screen_off_timeout 60000"); 
                            //UpdateDeviceStatus(p.deviceID, "Đang skip setup google");
                            //KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 84.9, 90.4);
                            //Thread.Sleep(6000);
                            //List<string> textsToCheck = new List<string> { "SET UP OFFLINE", "THIẾT LẬP MÀ KHÔNG CÓ MẠNG?" };
                            //// Time in seconds
                            //if (p.IsHaveTextList(textsToCheck))
                            //{
                            //    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 29.0, 89.7);
                            //    Thread.Sleep(1000);
                            //    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 81.2, 65.3);
                            //    Thread.Sleep(200);
                            //    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 78.8, 62.8);
                            //    Thread.Sleep(2000);
                            //}
                            //else
                            //{
                            //    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 7.0, 90.0);//skip
                            //    Thread.Sleep(3000);
                            //    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 47.3, 80.5);
                            //    Thread.Sleep(3000);
                            //    p.ImgForTime(p.dataBitmap.network, 10);
                            //    p.ClickImg(p.dataBitmap.network);
                            //    Thread.Sleep(2000);
                            //    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 84.5, 57.0);

                            //    Thread.Sleep(2000);

                            //}


                            //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell pm disable-user --user 0 com.google.android.setupwizard");
                            //Thread.Sleep(5000);
                            //UpdateDeviceStatus(p.deviceID, "Đang mua mail");

                            //DichVuGmail dichVuGmail = new DichVuGmail();
                            //bool isSuccess = false;

                            //while (!isSuccess)
                            //{
                            //    lock (_lockObject)
                            //    {
                            //        dichVuGmail.GetGmail("FCrpyKVO1cWFFrwKXMhEnaoWH0Pp6Kqq");

                            //        if (dichVuGmail.Username != null && dichVuGmail.Password != null)
                            //        {
                            //            isSuccess = true;

                            //            Dispatcher.Invoke(() =>
                            //            {
                            //                deviceInfos.Add(new DeviceInfo
                            //                {
                            //                    DevicesID = p.deviceID,
                            //                    UserGmail = dichVuGmail.Username,
                            //                    PasswordGmail = dichVuGmail.Password
                            //                });
                            //            });
                            //        }
                            //    }
                            //}


                            //p.addGmail("braunkadinis17@gmail.com", "OdinReevee16");

                            //p.reg();
                            //KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 48.0, 95.6);
                            ////backup
                            //Thread.Sleep(5000);
                            //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} reboot recovery");
                            //Thread.Sleep(30000);


                            //bool isRecovery = false;
                            //while (!isRecovery)
                            //{
                            //    // Kiểm tra trạng thái của thiết bị với adb devices
                            //    string devicesList = KAutoHelper.ADBHelper.ExecuteCMD("adb devices");

                            //    // Kiểm tra xem thiết bị có trong danh sách và đang ở chế độ recovery hay không
                            //    if (devicesList.Contains($"{p.deviceID}\trecovery"))
                            //    {
                            //        isRecovery = true;
                            //    }
                            //    else
                            //    {
                            //        // Nếu chưa vào recovery, chờ một lúc rồi kiểm tra lại
                            //        Thread.Sleep(2000); // Chờ 2 giây trước khi kiểm tra lại
                            //    }
                            //}
                            //string path = $"C:\\Users\\CHI\\Downloads\\shopee\\{p.deviceID}";
                            //string basePath = path;


                            //int version = 1;
                            //while (Directory.Exists(path))
                            //{
                            //    path = $"{basePath}\\{version}";
                            //    version++;
                            //}


                            //Directory.CreateDirectory(path);

                            ////backup token
                            //ExecuteCMD($@"adb -s {p.deviceID} shell ""cp -r /data/data/com.shopee.vn/shared_prefs /sdcard/ShopeeBackup""");
                            ////KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull sdcard/com.shopee.vn.tar {path}");
                            //KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull /sdcard/ShopeeBackup {path}");
                            ////backup cookie
                            ////ExecuteCMD($@"adb -s {p.deviceID} shell ""cp /data/data/com.shopee.vn/cache/HTTP_CACHE /sdcard""");

                            //string usersFolderPath = System.IO.Path.Combine(path, "users");
                            //KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull data/system/users {usersFolderPath}");

                            ////KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull data/data/com.shopee.vn/shared_prefs/login.xml {path}");
                            //UpdateDeviceStatus(p.deviceID, "xong");

                            //ExecuteCMD($@"adb -s {p.deviceID} shell twrp format data");

                            ////mở usb debugging
                            //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell mkdir -p /data/misc/adb");
                            //KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} push C:\Users\CHI\.android\adbkey.pub /data/misc/adb/adb_keys");
                            //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell chmod 644 /data/misc/adb/adb_keys");
                            //KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} reboot");
                            //UpdateDeviceStatus(p.deviceID, "Đang chờ khởi động lại");
                            //Thread.Sleep(100000);
                            //List<string> textsToCheck2 = new List<string> { "BẮT ĐẦU" };
                            //p.TextForTimeList(textsToCheck2,25);
                        }
                      
                        
                    }
                    catch
                    {

                        UpdateDeviceStatus(p.deviceID, "bị lỗi");


                    }

                });
                t.Start();
                t.IsBackground = true;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            List<String> Devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var item in Devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    
                    KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 84.9, 90.4);
                    Thread.Sleep(5000);
                    List<string> textsToCheck = new List<string> { "SET UP OFFLINE", "THIẾT LẬP MÀ KHÔNG CÓ MẠNG?" };
                    // Time in seconds
                    if (p.IsHaveTextList(textsToCheck))
                    {
                        KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 29.0, 89.7);
                        Thread.Sleep(1000);
                        KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 81.2, 65.3);
                        Thread.Sleep(200);
                        KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 78.8, 62.8);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 7.0, 90.0);//skip
                        Thread.Sleep(3000);
                        KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 47.3, 80.5);
                        Thread.Sleep(3000);
                        p.ImgForTime(p.dataBitmap.network, 10);
                        p.ClickImg(p.dataBitmap.network);
                        Thread.Sleep(2000);
                        KAutoHelper.ADBHelper.TapByPercent(p.deviceID, 84.5, 57.0);

                        Thread.Sleep(2000);

                    }

                  
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell pm disable-user --user 0 com.google.android.setupwizard");

                });
                t.Start();
                t.IsBackground = true;

            }

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            List<string> devices = GetDevicesRecovery();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                   
                    //UpdateDeviceStatus(p.deviceID, "Vào recovery");

                    //KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} reboot recovery");
                    //Thread.Sleep(30000);
                    UpdateDeviceStatus(p.deviceID, "Đang backup");
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell twrp backup data");
                    Thread.Sleep(1000);

               
                    UpdateDeviceStatus(p.deviceID, "Đang đẩy file sang máy tính");

                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} pull /sdcard/Fox ./Cookie");
                    Thread.Sleep(1000);

                   
                    UpdateDeviceStatus(p.deviceID, "Đang xóa dữ liệu");

                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell twrp format data");
                    Thread.Sleep(2000);
                 
                    UpdateDeviceStatus(p.deviceID, "Xong");

                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} reboot");

                 

                });
                t.Start();
                t.IsBackground = true;
            }

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            List<String> Devices = GetDevicesRecovery();
            foreach (var item in Devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} pull /sdcard/Fox D:\\Shopee_backup");

                });
                t.Start();
                t.IsBackground = true;

            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            List<String> Devices = GetDevicesRecovery();
            foreach (var item in Devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell twrp format data");

                });
                t.Start();
                t.IsBackground = true;

            }
        }
        private void UpdateDeviceInfo(string deviceID, Action<DeviceInfo> updateAction)
        {
            Dispatcher.Invoke(() =>
            {
                var deviceInfo = deviceInfos.FirstOrDefault(d => d.DevicesID == deviceID);
                if (deviceInfo != null)
                {
                    updateAction(deviceInfo);
                }
                else
                {
                    deviceInfo = new DeviceInfo { DevicesID = deviceID };
                    updateAction(deviceInfo);
                    deviceInfos.Add(deviceInfo);
                }
            });
        }

        // Sử dụng phương thức rút gọn để cập nhật trạng thái thiết bị
        private void UpdateDeviceStatus(string deviceID, string status)
        {
            UpdateDeviceInfo(deviceID, deviceInfo => deviceInfo.Status = status);
        }

        // Sử dụng phương thức rút gọn để cập nhật cookie của thiết bị
        private void UpdateDeviceCookie(string deviceID, string cookie)
        {
            UpdateDeviceInfo(deviceID, deviceInfo => deviceInfo.Cookie = cookie);
        }
        private void UpdateDeviceUsername(string deviceID, string username)
        {
            UpdateDeviceInfo(deviceID, deviceInfo => deviceInfo.UserGmail = username);
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_dn(object sender, RoutedEventArgs e)
        {
            string directoryPath = tbPath.Text;
            _viewModel.LoadFiles(directoryPath);
        }
        public class FileViewModel
        {
            public ObservableCollection<FileItem> FileItems { get; set; }
            public ICommand ShowDetailsCommand { get; private set; }
            public ICommand RenameFolderCommand { get; private set; }
            public ICommand ShowProxyy { get; private set; }
            //ShowProxyy
            public FileViewModel()
            {
                FileItems = new ObservableCollection<FileItem>();
                ShowDetailsCommand = new RelayCommand<FileItem>(ShowDetails);
                RenameFolderCommand = new RelayCommand<FileItem>(RenameFolder);
                ShowProxyy = new RelayCommand<FileItem>(Selectproxy);
            }

            public void LoadFiles(string directoryPath)
            {
                FileItems.Clear();

                if (Directory.Exists(directoryPath))
                {
                    var directories = Directory.GetDirectories(directoryPath);
                    var files = Directory.GetFiles(directoryPath);

                    foreach (var dir in directories)
                    {
                        FileItems.Add(new FileItem
                        {
                            Path = dir,
                            Status = "Directory",
                            ShowDetailsCommand = ShowDetailsCommand
                        });
                    }

                    foreach (var file in files)
                    {
                        FileItems.Add(new FileItem
                        {
                            Path = file,
                            Status = "File",
                            ShowDetailsCommand = ShowDetailsCommand
                        });
                    }
                }
            }

            private void ShowDetails(object parameter)
            {
                if (parameter is FileItem item)
                {
                    // Get the list of connected devices
                    List<string> devices = GetDevicesRecovery();

                    if (devices.Count > 0)
                    {
                        // Prompt user to select a device
                        string selectedDevice = ShowDeviceSelectionDialog(devices);
                      
                        if (!string.IsNullOrEmpty(selectedDevice))
                        {
                          
                      
                            Thread t = new Thread(() =>
                            {
                                item.Status = $"Đang đăng nhập {item.Path} sang {selectedDevice}";
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} push {item.Path} /sdcard/Backup");
                                item.Status = "Đang restore " + selectedDevice;
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} shell twrp restore /sdcard/Backup --data");
                                item.Status = selectedDevice;
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} reboot");
                            });
                            t.Start();
                            
                        }
                        else
                        {
                            MessageBox.Show("No device selected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No devices found.");
                    }
                }
            }

            private void Selectproxy(object parameter)
            {
                if (parameter is FileItem item)
                {
                    // Get the list of connected devices
                    List<string> proxy = new List<string>(File.ReadAllLines("Proxy/Key.txt"));
                    List<string> devices = KAutoHelper.ADBHelper.GetDevices();
                    if (devices.Count > 0)
                    {
                        // Prompt user to select a device
                        string slectKey = Showkey(proxy);
                        string selectedDevice = ShowDeviceSelectionDialog(devices);
                        if (!string.IsNullOrEmpty(selectedDevice))
                        {
                           
                            // Show the details of the selected file/directory and selected device
                            //MessageBox.Show($"Selected Path: {item.Path}\nStatus: {item.Status}\nSelected Device: {selectedDevice}");
                            Thread t = new Thread(() =>
                            {
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} install Proxy/app-debug.apk");
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} shell am force-stop com.example.webweb");
                                Thread.Sleep(1000);
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} shell settings put global http_proxy :0");
                                Thread.Sleep(1000);
                                KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {selectedDevice} shell am start -n com.example.webweb/.MainActivity --es ""proxy_key"" ""{slectKey}""");
                                Thread.Sleep(3000);
                                TinsoftProxy tinsoftProxy = new TinsoftProxy();
                                tinsoftProxy.getProxy(slectKey);
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} shell settings put global http_proxy {tinsoftProxy.Host}:{tinsoftProxy.Port}");
                                Thread.Sleep(500);
                                KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {selectedDevice} shell am start -n com.shopee.vn/com.shopee.app.ui.home.HomeActivity_");
                            });
                            t.Start();

                        }
                        else
                        {
                            MessageBox.Show("No device selected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No devices found.");
                    }
                }
            }

            private void RenameFolder(FileItem item)
            {
                if (item != null)
                {
                    // Create a dialog to input the new name
                    var renameDialog = new RenameDialogWindow(item.Path);
                    if (renameDialog.ShowDialog() == true)
                    {
                        string newName = renameDialog.NewName;
                        if (!string.IsNullOrEmpty(newName))
                        {
                            try
                            {
                                string newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(item.Path), newName);
                                Directory.Move(item.Path, newPath);
                                item.Path = newPath; // Update the item's path
                                item.Status = "Renamed to " + newName;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error renaming folder: " + ex.Message);
                            }
                        }
                    }
                }
            }

            private List<string> GetDevicesRecovery()
            {
                // Use ADBHelper to get the list of connected devices
                List<string> list = new List<string>();
                string input = KAutoHelper.ADBHelper.ExecuteCMD("adb devices");
                string pattern = "(?<=List of devices attached)([^\\n]*\\n+)+";
                MatchCollection matchCollection = Regex.Matches(input, pattern, RegexOptions.Singleline);
                if (matchCollection.Count > 0)
                {
                    string value = matchCollection[0].Groups[0].Value;
                    string[] array = Regex.Split(value, "\r\n");
                    string[] array2 = array;
                    foreach (string text in array2)
                    {
                        if (string.IsNullOrEmpty(text) || !(text != " "))
                        {
                            continue;
                        }

                        string[] array3 = text.Trim().Split('\t');
                        string text2 = array3[0];
                        string text3 = "";
                        try
                        {
                            text3 = array3[1];
                            if (text3 != "recovery" && text3 != "sideload")
                            {
                                continue;
                            }
                        }
                        catch
                        {
                        }

                        list.Add(text2.Trim());
                    }
                }

                return list;
            }
            private string ShowDeviceSelectionDialog(List<string> devices)
            {
                // Create a new window for device selection
                var window = new Window
                {
                    Title = "Chọn thiết bị",
                    Width = 300,
                    Height = 150,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                var comboBox = new ComboBox
                {
                    ItemsSource = devices,
                    Margin = new Thickness(10)
                };

                // Handle the SelectionChanged event to close the window and return the selected value
                comboBox.SelectionChanged += (s, e) =>
                {
                    if (comboBox.SelectedItem != null)
                    {
                        window.DialogResult = true;
                        window.Close(); // Close the window when an item is selected
                    }
                };

                var stackPanel = new StackPanel();
                stackPanel.Children.Add(comboBox);

                window.Content = stackPanel;

                if (window.ShowDialog() == true && comboBox.SelectedItem != null)
                {
                    return comboBox.SelectedItem.ToString();
                }

                return null;
            }
            private string Showkey(List<string> devices)
            {
                // Create a new window for device selection
                var window = new Window
                {
                    Title = "Chọn thiết bị",
                    Width = 300,
                    Height = 150,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen
                };

                var comboBox = new ComboBox
                {
                    ItemsSource = devices,
                    Margin = new Thickness(10)
                };

                // Handle the SelectionChanged event to close the window and return the selected value
                comboBox.SelectionChanged += (s, e) =>
                {
                    if (comboBox.SelectedItem != null)
                    {
                        window.DialogResult = true;
                        window.Close(); // Close the window when an item is selected
                    }
                };

                var stackPanel = new StackPanel();
                stackPanel.Children.Add(comboBox);

                window.Content = stackPanel;

                if (window.ShowDialog() == true && comboBox.SelectedItem != null)
                {
                    return comboBox.SelectedItem.ToString();
                }

                return null;
            }


            public ObservableCollection<FileItem> GetSelectedItems()
            {
                return new ObservableCollection<FileItem>(FileItems.Where(i => i.IsSelected));
            
            }
        }
        public MailServer oServer;
        public MailClient oClient;
        private void Button_Click_GetSelectedItems(object sender, RoutedEventArgs e)
        {
        
       
        }
        public static string ExecuteCMD(string cmdCommand)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = @"D:\C#\regacc\Regacc\bin\Debug", // Đặt đường dẫn đến thư mục chứ không phải file adb.exe
                    FileName = "cmd.exe",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    Verb = "runas"
                };
                process.StartInfo = processStartInfo;
                process.Start();

                // Ghi lệnh và thêm lệnh 'exit' để đóng CMD sau khi thực thi
                process.StandardInput.WriteLine(cmdCommand);
                process.StandardInput.WriteLine("exit");
                process.StandardInput.Flush();
                process.StandardInput.Close();

                // Đọc toàn bộ kết quả của CMD
                string output = process.StandardOutput.ReadToEnd();

                // Đợi CMD thoát ra trước khi trả kết quả
                process.WaitForExit();

                return output;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<string> devices = KAutoHelper.ADBHelper.GetDevices();
            //List<string> devices = GetDevicesRecovery();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} reboot recovery");
                    Thread.Sleep(30000);
                    string path = $"C:\\Users\\CHI\\Downloads\\shopee\\{p.deviceID}";
                    string basePath = path;


                    int version = 1;
                    while (Directory.Exists(path))
                    {
                        path = $"{basePath}\\{version}";
                        version++;
                    }


                    Directory.CreateDirectory(path);


                    ExecuteCMD($@"adb -s {p.deviceID} shell ""cd /data/data/com.shopee.vn && tar -cvf /sdcard/com.shopee.vn.tar .""");
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull sdcard/com.shopee.vn.tar {path}");


                    string usersFolderPath = System.IO.Path.Combine(path, "users");
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull data/system/users {usersFolderPath}");
                    UpdateDeviceStatus(p.deviceID,"xong");
                    ExecuteCMD($@"adb -s {p.deviceID} shell twrp format data");
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} reboot");

                });
                t.Start();
                t.IsBackground = true;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<string> devices = GetDevicesRecovery();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {

                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} push ""C:\Users\CHI\Downloads\shopee\9294dafc\6\com.shopee.vn.tar"" /sdcard");

                    ExecuteCMD($@"adb -s {p.deviceID} shell ""tar -xvf /sdcard/com.shopee.vn.tar -C /data/data/com.shopee.vn""");

                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} push ""C:\Users\CHI\Downloads\shopee\d366aa33\3\users"" /data/system");
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} reboot");
                });
                t.Start();
                t.IsBackground = true;
            }
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s 2b17f93 shell mkdir -p /data/misc/adb");
            KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s 2b17f93 push C:\Users\CHI\.android\adbkey.pub /data/misc/adb/adb_keys");
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s 2b17f93 shell chmod 644 /data/misc/adb/adb_keys");
            KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s 2b17f93 reboot");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            List<string> devices = GetDevicesRecovery();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                   
                    string sourcePath = "/data/data/com.shopee.vn/app_webview_com.shopee.vn/Default/Cookies";
                    string destinationPath = $@"./Cookie/{p.deviceID}Cookies"; // Đường dẫn nơi bạn muốn lưu tệp
                    var cookieReader = new CookieReader(destinationPath);
             
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} pull {sourcePath} \"{destinationPath}\"");


                    string username = new CookieReader(destinationPath)
             .GetCookieValues(new List<string> { "username" })[0]
             .Split('=')[1];

                    File.Move(destinationPath, $"./Cookie/{username}");

                    string usersFolderPath = $"./Cookie/{username}users";
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull data/system/users {usersFolderPath}");
                    ExecuteCMD($@"adb -s {p.deviceID} shell twrp format data");
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell mkdir -p /data/misc/adb");
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} push C:\Users\CHI\.android\adbkey.pub /data/misc/adb/adb_keys");
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell chmod 644 /data/misc/adb/adb_keys");
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} reboot");
                    UpdateDeviceStatus(p.deviceID, "Đang chờ khởi động lại");

                });
                t.Start();
                t.IsBackground = true;
            }
            
          


        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string name = "23n2gdyayz";
            string destinationPath = $@"./Cookie/{name}";
            var cookieReader = new CookieReader(destinationPath);
            string[] results = cookieReader.GetCookieValues(new List<string> { "SPC_ST", "SPPC_EC" });



        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            KAutoHelper.ADBHelper.ExecuteCMD($"adb -s 2b17f93 shell mkdir -p /data/data/com.shopee.vn/shared_prefs");
            string name = "c4pz5v92wm";
            string destinationPath = $@"./Cookie/{name}";
            var cookieReader = new CookieReader(destinationPath);

            string username = cookieReader.GetCookieValues(new List<string> { "username" })[0].Split('=')[1];
            string userIdLong = cookieReader.GetCookieValues(new List<string> { "userid" })[0].Split('=')[1];
            string vCodeToken = cookieReader.GetCookieValues(new List<string> { "shopee_token" })[0].Split('=')[1];
            string shopIdLong = cookieReader.GetCookieValues(new List<string> { "shopid" })[0].Split('=')[1];

         
         
         
            bool lineLogin = false;
            string password = "********************************";
    
       
    
          
        

            // XML content with variables
            string xmlContent = $@"<?xml version='1.0' encoding='utf-8' standalone='yes' ?>
<map>
    <long name='userIdLong' value='{userIdLong}' />
    <string name='country'></string>
    <boolean name='isSeller' value='false' />
    <boolean name='isToBAccount' value='false' />
    <string name='lineId'></string>
    <string name='avatar'></string>
    <string name='spcTIV'></string>
    <string name='token'>{vCodeToken}</string>
    <boolean name='lineLogin' value='{lineLogin.ToString().ToLower()}' />
    <string name='password'>{password}</string>
    <long name='shopIdLong' value='{shopIdLong}' />
    <string name='vCodeToken'>{vCodeToken}</string>
    <boolean name='fbLogin' value='false' />
    <string name='phone'></string>
    <string name='fbId'></string>
    <string name='spcTID'></string>
    <string name='email'></string>
    <string name='username'>{username}</string>
</map>";

            // Define file path
            string filePath = $"./Cookie/login{name}.xml";

            // Write to file
            File.WriteAllText(filePath, xmlContent);

            Console.WriteLine("XML data has been written to " + filePath);
        }

        private  void Button_Click_10(object sender, RoutedEventArgs e)
        {

            List<string> devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    var bitmap = ADBHelper.ScreenShoot(p.deviceID, isDeleteImageAfterCapture: false);
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} pull /sdcard/screenShoot{p.deviceID}.png ./imgUpload/");
                    // string linkImg= p.UploadImageToImgur();
                    string jsonResponse = p.UploadImageToImgur($"screenShoot{p.deviceID}.png", "546c25a59c58ad7");

                    // Phân tích phản hồi JSON để lấy liên kết ảnh
                    JObject json = JObject.Parse(jsonResponse);
                    string linkImg = json["data"]["link"].ToString();
                    Clipboard.SetText(linkImg);

                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.IsBackground = true;
            }

          
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
           
            List<string> devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell am start -n com.shopee.vn/com.shopee.app.ui.home.HomeActivity_ https://vn.shp.ee/qcwS9cT");

                });
                t.Start();
                t.IsBackground = true;
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {


            List<string> devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    var bitmap = ADBHelper.ScreenShoot(p.deviceID, isDeleteImageAfterCapture: false);
                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} pull /sdcard/screenShoot{p.deviceID}.png ./imgUpload/");
                    // string linkImg= p.UploadImageToImgur();
                    string jsonResponse = p.UploadImageToImgur($"screenShoot{p.deviceID}.png", "546c25a59c58ad7");

                    // Phân tích phản hồi JSON để lấy liên kết ảnh
                    JObject json = JObject.Parse(jsonResponse);
                    string linkImg = json["data"]["link"].ToString();
                    UpdateDeviceStatus(p.deviceID, linkImg);

                });
              
                t.Start();
                t.IsBackground = true;
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            List<string> devices = GetDevicesRecovery();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    string sourcePath = "/data/data/com.shopee.vn/app_webview_com.shopee.vn/Default/Cookies";
                    string destinationPath = $@"./Cookie/{p.deviceID}Cookies"; // Đường dẫn nơi bạn muốn lưu tệp
                    var cookieReader = new CookieReader(destinationPath);

                    KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} pull {sourcePath} \"{destinationPath}\"");


                    string username = new CookieReader(destinationPath)
             .GetCookieValues(new List<string> { "username" })[0]
             .Split('=')[1];

                    File.Move(destinationPath, $"./Cookie/{username}");

                    string usersFolderPath = $"./Cookie/{username}users";
                    KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} pull data/system/users {usersFolderPath}");
                    string cookie = new CookieReader($"./Cookie/{username}")
           .GetCookieValues(new List<string> { "SPC_ST" })[0];

                    UpdateDeviceCookie(p.deviceID, cookie);
                    UpdateDeviceUsername(p.deviceID, $"https://shopee.vn/{username}");
                   
                   
                });
              
                t.Start();
                t.IsBackground = true;
            }

        }
        private DeviceInfo GetDeviceData(string deviceID)
        {
            foreach (DeviceInfo deviceInfo in dataGridTab1.Items)
            {
                if (deviceInfo.DevicesID == deviceID)
                {
                    return deviceInfo;
                }
            }
            return null;
        }



        private void Button_Click_14(object sender, RoutedEventArgs e)
        {

            List<string> devices = GetDevicesRecovery();
            foreach (var item in devices)
            {
                Phone p = new Phone(item);
                Thread t = new Thread(() =>
                {
                    // Lấy dữ liệu của thiết bị cụ thể
                    DeviceInfo deviceData = GetDeviceData(p.deviceID);
                    if (deviceData != null)
                    {
                        string deviceID = deviceData.DevicesID;
                        string userGmail = deviceData.UserGmail;
                        string passwordGmail = deviceData.PasswordGmail;
                        string status = deviceData.Status;
                        string cookie = deviceData.Cookie;
                        string ids = deviceData.OKOK;

                        // Thực hiện các thao tác với dữ liệu đã lấy
                        string result = p.UpdateCookie(cookie, 1, ids, $"{status},{userGmail}");
                        ExecuteCMD($@"adb -s {p.deviceID} shell twrp format data");
                        KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell mkdir -p /data/misc/adb");
                        KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} push C:\Users\CHI\.android\adbkey.pub /data/misc/adb/adb_keys");
                        KAutoHelper.ADBHelper.ExecuteCMD($"adb -s {p.deviceID} shell chmod 644 /data/misc/adb/adb_keys");
                        KAutoHelper.ADBHelper.ExecuteCMD($@"adb -s {p.deviceID} reboot");
                    }
                    else
                    {
                        Console.WriteLine($"Device with ID {p.deviceID} not found in DataGrid.");
                    }
                });

                t.IsBackground = true;
                t.Start();
            }


        }
    }
  

    public class DeviceInfo : INotifyPropertyChanged
    {
        private bool isSelected;
        private string devicesID;
        private string userGmail;
        private string passwordGmail;
        private string status;
        private string cookie;
        private string okok;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; OnPropertyChanged(nameof(IsSelected)); }
        }

        public string DevicesID
        {
            get { return devicesID; }
            set { devicesID = value; OnPropertyChanged(nameof(DevicesID)); }
        }

        public string UserGmail
        {
            get { return userGmail; }
            set { userGmail = value; OnPropertyChanged(nameof(UserGmail)); }
        }

        public string PasswordGmail
        {
            get { return passwordGmail; }
            set { passwordGmail = value; OnPropertyChanged(nameof(PasswordGmail)); }
        }
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }
        public string Cookie
        {
            get { return cookie; }
            set { cookie = value; OnPropertyChanged(nameof(Cookie)); }
        }
        public string OKOK
        {
            get { return okok; }
            set { okok = value; OnPropertyChanged(nameof(OKOK)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FileItem : INotifyPropertyChanged
    {
        private string _path;
        private bool _isSelected;
        private string _status;

        // Property for checkbox selection
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        // Property for the file/directory path
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        // Property for the status
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        // Command for the button
        public ICommand ShowDetailsCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }


}
