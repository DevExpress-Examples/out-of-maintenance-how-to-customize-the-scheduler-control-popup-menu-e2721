Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Scheduler
Imports DevExpress.Xpf.Scheduler.Menu
Imports DevExpress.Xpf.Scheduler.UI
Imports DevExpress.XtraScheduler
Imports System
Imports System.Windows

Namespace CustomMenu
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            schedulerControl1.Storage.AppointmentStorage.Add(New Appointment(Date.Now, Date.Now.AddHours(1.5)))
            schedulerControl1.ActiveView.GotoTimeInterval(New TimeInterval(Date.Now.AddHours(-2), Date.Now.AddHours(-1)))
        End Sub

        #Region "#PopupMenuShowing"
        Private Sub schedulerControl1_PopupMenuShowing(ByVal sender As Object, ByVal e As SchedulerMenuEventArgs)
            ' Check whether this event was raised for a default popup menu of the Scheduler control.
            If e.Menu.Name = SchedulerMenuItemName.DefaultMenu Then
                For i As Integer = 0 To e.Menu.Items.Count - 1
                    Dim menuItem As SchedulerBarItem = TryCast(e.Menu.Items(i), SchedulerBarItem)
                    If menuItem IsNot Nothing Then
                        If menuItem IsNot Nothing AndAlso menuItem.Name = SchedulerMenuItemName.NewAllDayEvent Then
                            menuItem.Content = "New Task for the Entire Day"
                            Exit For
                        End If
                    End If
                Next i

                ' Remove the New Recurring Event menu item using the Action approach.
                e.Customizations.Add(New RemoveBarItemAndLinkAction() With {.ItemName = SchedulerMenuItemName.NewRecurringEvent})

                ' Create a custom menu item.
                Dim myMenuItem As New BarButtonItem()
                myMenuItem.Name = "customItem"
                myMenuItem.Content = "Item Added in CodeBehind"
                AddHandler myMenuItem.ItemClick, AddressOf customItem_ItemClick

                ' Insert a menu separator.
                e.Customizations.Add(New BarItemLinkSeparator())
                ' Insert a new item into the Scheduler popup menu.
                e.Customizations.Add(myMenuItem)
            End If
        End Sub

        Private Sub customItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ' Implement a custom action.
            ' ...
        End Sub
        #End Region ' #PopupMenuShowing

        #Region "#AppointmentPopupMenuCustomization"
        Private Sub customCheckItem_CheckedChanged(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ' Implement a custom action.
            ' ...
        End Sub

        Private Sub customButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
            ' Implement a custom action.
            ' ...
        End Sub
        #End Region ' #AppointmentPopupMenuCustomization


    End Class
End Namespace
