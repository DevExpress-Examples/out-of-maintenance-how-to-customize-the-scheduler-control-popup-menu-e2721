using System;
using System.Windows;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Scheduler;
using DevExpress.Xpf.Scheduler.Menu;
using DevExpress.Xpf.Scheduler.UI;
using DevExpress.XtraScheduler;

namespace CustomMenu {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Appointment apt = schedulerControl1.Storage.CreateAppointment(AppointmentType.Normal, DateTime.Now, DateTime.Now.AddHours(1.5),"Test Appointment");
            apt.LabelKey = 1;
            schedulerControl1.Storage.AppointmentStorage.Add(apt);
            schedulerControl1.ActiveView.GotoTimeInterval(new TimeInterval(DateTime.Now.AddHours(-2), DateTime.Now.AddHours(-1)));
        }

        #region #PopupMenuShowing
        private void schedulerControl1_PopupMenuShowing(object sender, SchedulerMenuEventArgs e) {
            // Check whether this event was raised for a default popup menu of the Scheduler control.
            if (e.Menu.Name == SchedulerMenuItemName.DefaultMenu)
            {
                for (int i = 0; i < e.Menu.Items.Count; i++)
                {
                    SchedulerBarItem menuItem = e.Menu.Items[i] as SchedulerBarItem;
                    if (menuItem != null)
                    {
                        if (menuItem != null && menuItem.Name == SchedulerMenuItemName.NewAllDayEvent)
                        {
                            menuItem.Content = "Create All-Day Appointment";
                            break;
                        }
                    }
                }

                // Remove the New Recurring Event menu item using the Action approach.
                e.Customizations.Add(new RemoveBarItemAndLinkAction()
                {
                    ItemName = SchedulerMenuItemName.NewRecurringEvent
                });

                // Create a custom menu item.
                BarButtonItem myMenuItem = new BarButtonItem();
                myMenuItem.Name = "customItem";
                myMenuItem.Content = "Item Added at Runtime";
                myMenuItem.ItemClick += new ItemClickEventHandler(customItem_ItemClick);

                // Insert a menu separator.
                e.Customizations.Add(new BarItemLinkSeparator());
                // Insert a new item into the Scheduler popup menu.
                e.Customizations.Add(myMenuItem);
            } 
        }

        private void customItem_ItemClick(object sender, ItemClickEventArgs e) {
            // Implement a custom action.
            MessageBox.Show(String.Format("{0} is clicked", e.Item.Name));
        }
        #endregion #PopupMenuShowing

        private void customCheckItem_CheckedChanged(object sender, ItemClickEventArgs e) {
            // Implement a custom action.
            MessageBox.Show(String.Format("{0} is clicked", e.Item.Name));
        }

        private void customButtonItem_ItemClick(object sender, ItemClickEventArgs e) {
            // Implement a custom action.
            MessageBox.Show(String.Format("{0} is clicked", e.Item.Name));
        }
    }
}
