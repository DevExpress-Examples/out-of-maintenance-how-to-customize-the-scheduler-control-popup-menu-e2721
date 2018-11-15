<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/PopupMenuCustomization/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/PopupMenuCustomization/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/PopupMenuCustomization/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/PopupMenuCustomization/MainWindow.xaml))
<!-- default file list end -->
# How to customize the Scheduler control popup menu


<p>The following example illustrates how to customize the Scheduler control popup menus by removing existing menu items and adding new items to the <strong>Default Popup Menu</strong> and <strong>Appointment Popup Menu</strong>.<br>In XAML, add new <a href="http://help.devexpress.com/#WPF/clsDevExpressXpfBarsBarItemtopic">BarItem elements</a> and <a href="http://help.devexpress.com/#WPF/clsDevExpressXpfBarsRemoveBarItemAndLinkActiontopic">RemoveBarItemAndLinkAction</a> actions to the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulerSchedulerControl_DefaultMenuCustomizationstopic">DefaultMenuCustomizations</a> and <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulerSchedulerControl_AppointmentMenuCustomizationstopic">AppointmentMenuCustomizations</a> collections.<br>At runtime, handle the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulerSchedulerControl_PopupMenuShowingtopic">PopupMenuShowing</a> event and add new <a href="http://help.devexpress.com/#WPF/clsDevExpressXpfBarsBarItemtopic">BarItem elements</a> and <a href="http://help.devexpress.com/#WPF/clsDevExpressXpfBarsRemoveBarItemAndLinkActiontopic">RemoveBarItemAndLinkAction</a> actions to the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulerSchedulerMenuEventArgs_Customizationstopic">e.Customizations</a> collection.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-customize-the-scheduler-control-popup-menu-e2721/13.1.4+/media/f4c1eff8-7c68-4895-9d5e-1b508f8e578c.png"><br><br></p>


<h3>Description</h3>

<p>Popup menu customization can be performed either at design time (via the XAML markup), or at runtime (via the code-behind file).<br /> To modify a popup menu at runtime, handle the <strong>SchedulerControl.PopupMenuShowing</strong> event. In this event handler, all modifications to the list of menu items can be made by changing the <strong>SchedulerMenuEventArgs.Customizations</strong> collection. To get access to a popup menu for which the event has been raised, use the <strong>SchedulerMenuEventArgs.Menu</strong> property. <br /> To customize the Scheduler control default and appointment popup menus at design time, you can also use the <strong>SchedulerControl.DefaultMenuCustomizations</strong> and <strong>SchedulerControl.AppointmentMenuCustomizations</strong> properties respectively.<br /> In both cases, to remove a specific menu item along with its link, use the <strong>RemoveBarItemAndLinkAction</strong> instance, and to add a custom menu item, add a new <strong>BarButtonItem</strong> or <strong>BarCheckItem</strong> object to the Customizations collection.</p>

<br/>


