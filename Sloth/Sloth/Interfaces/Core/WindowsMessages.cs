using System;

namespace Sloth.Core
{
    /// <summary>
    /// Windows Messages
    /// Defined in winuser.h from Windows SDK v6.1
    /// Documentation pulled from MSDN.
    /// </summary>
    public enum WM : Int32
    {
        /// <summary>
        /// The WM_NULL message performs no operation. An application sends the WM_NULL message if it wants to post a message that the recipient window will ignore.
        /// </summary>
        Null = 0x0000,
        /// <summary>
        /// The WM_Create message is sent when an application requests that a window be created by calling the CreateWindowEx or CreateWindow function. (The message is sent before the function returns.) The window procedure of the new window receives this message after the window is created, but before the window becomes visible.
        /// </summary>
        Create = 0x0001,
        /// <summary>
        /// The WM_Destroy message is sent when a window is being destroyed. It is sent to the window procedure of the window being destroyed after the window is removed from the screen. 
        /// This message is sent first to the window being destroyed and then to the child windows (if any) as they are destroyed. During the processing of the message, it can be assumed that all child windows still exist.
        /// /// </summary>
        Destroy = 0x0002,
        /// <summary>
        /// The WM_Move message is sent after a window has been moved. 
        /// </summary>
        Move = 0x0003,
        /// <summary>
        /// The WM_Size message is sent to a window after its Size has changed.
        /// </summary>
        Size = 0x0005,
        /// <summary>
        /// The WM_Activate message is sent to both the window being activated and the window being deactivated. If the windows use the same input queue, the message is sent synchronously, first to the window procedure of the top-level window being deactivated, then to the window procedure of the top-level window being activated. If the windows use different input queues, the message is sent asynchronously, so the window is activated immediately. 
        /// </summary>
        Activate = 0x0006,
        /// <summary>
        /// The WM_SetFocus message is sent to a window after it has gained the keyboard focus. 
        /// </summary>
        SetFocus = 0x0007,
        /// <summary>
        /// The WM_KillFocus message is sent to a window immediately before it loses the keyboard focus. 
        /// </summary>
        KillFocus = 0x0008,
        /// <summary>
        /// The WM_Enable message is sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed. 
        /// </summary>
        Enable = 0x000A,
        /// <summary>
        /// An application sends the WM_SetRedraw message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn. 
        /// </summary>
        SetRedraw = 0x000B,
        /// <summary>
        /// An application sends a WM_SetText message to set the text of a window. 
        /// </summary>
        SetText = 0x000C,
        /// <summary>
        /// An application sends a WM_GetText message to copy the text that corresponds to a window into a buffer provided by the caller. 
        /// </summary>
        GetText = 0x000D,
        /// <summary>
        /// An application sends a WM_GetTextLength message to determine the length, in characters, of the text associated with a window. 
        /// </summary>
        GetTextLength = 0x000E,
        /// <summary>
        /// The WM_Paint message is sent when the system or another application makes a request to paint a portion of an application's window. The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_Paint message by using the GetMessage or PeekMessage function. 
        /// </summary>
        Paint = 0x000F,
        /// <summary>
        /// The WM_Close message is sent as a signal that a window or an application should terminate.
        /// </summary>
        Close = 0x0010,
        /// <summary>
        /// The WM_QueryEndSession message is sent when the user chooses to end the session or when an application calls one of the system shutdown functions. If any application returns zero, the session is not ended. The system stops sending WM_QueryEndSession messages as soon as one application returns zero.
        /// After processing this message, the system sends the WM_EndSession message with the wParam parameter set to the results of the WM_QueryEndSession message.
        /// </summary>
        QueryEndSession = 0x0011,
        /// <summary>
        /// The WM_QueryOpen message is sent to an icon when the user requests that the window be restored to its previous Size and position.
        /// </summary>
        QueryOpen = 0x0013,
        /// <summary>
        /// The WM_EndSession message is sent to an application after the system processes the results of the WM_QueryEndSession message. The WM_EndSession message informs the application whether the session is ending.
        /// </summary>
        EndSession = 0x0016,
        /// <summary>
        /// The WM_Quit message indicates a request to terminate an application and is generated when the application calls the PostQuitMessage function. It causes the GetMessage function to return zero.
        /// </summary>
        Quit = 0x0012,
        /// <summary>
        /// The WM_EraseBkgnd message is sent when the window background must be erased (for example, when a window is reSized). The message is sent to prepare an invalidated portion of a window for painting. 
        /// </summary>
        EraseBkgnd = 0x0014,
        /// <summary>
        /// This message is sent to all top-level windows when a change is made to a system color setting. 
        /// </summary>
        SysColorChange = 0x0015,
        /// <summary>
        /// The WM_ShowWindow message is sent to a window when the window is about to be hidden or shown.
        /// </summary>
        ShowWindow = 0x0018,
        /// <summary>
        /// An application sends the WM_WinIniChange message to all top-level windows after making a change to the Win.Ini file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in Win.Ini.
        /// Note  The WM_WinIniChange message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SettingChange message.
        /// </summary>
        WinIniChange = 0x001A,
        /// <summary>
        /// An application sends the WM_WinIniChange message to all top-level windows after making a change to the Win.Ini file. The SystemParametersInfo function sends this message after an application uses the function to change a setting in Win.Ini.
        /// Note  The WM_WinIniChange message is provided only for compatibility with earlier versions of the system. Applications should use the WM_SettingChange message.
        /// </summary>
        SettingChange = WinIniChange,
        /// <summary>
        /// The WM_DevModeChange message is sent to all top-level windows whenever the user changes device-mode settings. 
        /// </summary>
        DevModeChange = 0x001B,
        /// <summary>
        /// The WM_ActivateApp message is sent when a window belonging to a different application than the active window is about to be activated. The message is sent to the application whose window is being activated and to the application whose window is being deactivated.
        /// </summary>
        ActivateApp = 0x001C,
        /// <summary>
        /// An application sends the WM_FontChange message to all top-level windows in the system after changing the pool of font resources. 
        /// </summary>
        FontChange = 0x001D,
        /// <summary>
        /// A message that is sent whenever there is a change in the system time.
        /// </summary>
        TimeChange = 0x001E,
        /// <summary>
        /// The WM_CancelMode message is sent to cancel certain modes, such as Mouse capture. For example, the system sends this message to the active window when a dialog box or message box is displayed. Certain functions also send this message explicitly to the specified window regardless of whether it is the active window. For example, the EnableWindow function sends this message when disabling the specified window.
        /// </summary>
        CancelMode = 0x001F,
        /// <summary>
        /// The WM_SetCursor message is sent to a window if the Mouse causes the cursor to move within a window and Mouse input is not captured. 
        /// </summary>
        SetCursor = 0x0020,
        /// <summary>
        /// The WM_MouseActivate message is sent when the cursor is in an inactive window and the user presses a Mouse button. The parent window receives this message only if the child window passes it to the DefWindowProc function.
        /// </summary>
        MouseActivate = 0x0021,
        /// <summary>
        /// The WM_ChildActivate message is sent to a child window when the user clicks the window's title bar or when the window is activated, moved, or Sized.
        /// </summary>
        ChildActivate = 0x0022,
        /// <summary>
        /// The WM_QueueSync message is sent by a computer-based training (CBT) application to separate user-input messages from other messages sent through the WH_JournalPLAYBACK Hook procedure. 
        /// </summary>
        QueueSync = 0x0023,
        /// <summary>
        /// The WM_GetMinMaxInfo message is sent to a window when the Size or position of the window is about to change. An application can use this message to override the window's default maximized Size and position, or its default minimum or maximum tracking Size. 
        /// </summary>
        GetMinMaxInfo = 0x0024,
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_PaintIcon message is sent to a minimized window when the icon is to be painted. This message is not sent by newer versions of Microsoft Windows, except in unusual circumstances explained in the Remarks.
        /// </summary>
        PaintIcon = 0x0026,
        /// <summary>
        /// Windows NT 3.51 and earlier: The WM_IconEraseBkgnd message is sent to a minimized window when the background of the icon must be filled before painting the icon. A window receives this message only if a class icon is defined for the window; otherwise, WM_EraseBkgnd is sent. This message is not sent by newer versions of Windows.
        /// </summary>
        IconEraseBkgnd = 0x0027,
        /// <summary>
        /// The WM_NextDlgCtl message is sent to a dialog box procedure to set the keyboard focus to a different control in the dialog box. 
        /// </summary>
        NextDlgCtl = 0x0028,
        /// <summary>
        /// The WM_SpoolerStatus message is sent from Print Manager whenever a job is added to or removed from the Print Manager queue. 
        /// </summary>
        SpoolerStatus = 0x002A,
        /// <summary>
        /// The WM_DrawItem message is sent to the parent window of an owner-drawn button, combo box, list box, or menu when a visual aspect of the button, combo box, list box, or menu has changed.
        /// </summary>
        DrawItem = 0x002B,
        /// <summary>
        /// The WM_MeasureItem message is sent to the owner window of a combo box, list box, list view control, or menu item when the control or menu is created.
        /// </summary>
        MeasureItem = 0x002C,
        /// <summary>
        /// Sent to the owner of a list box or combo box when the list box or combo box is destroyed or when items are removed by the LB_DeleteSTRING, LB_RESetCONTENT, CB_DeleteSTRING, or CB_RESetCONTENT message. The system sends a WM_DeleteItem message for each deleted item. The system sends the WM_DeleteItem message for any deleted list box or combo box item with nonzero item data.
        /// </summary>
        DeleteItem = 0x002D,
        /// <summary>
        /// Sent by a list box with the LBS_WANTKeyBOARDInput style to its owner in response to a WM_KeyDown message. 
        /// </summary>
        VKeyTOItem = 0x002E,
        /// <summary>
        /// Sent by a list box with the LBS_WANTKeyBOARDInput style to its owner in response to a WM_Char message. 
        /// </summary>
        CharTOItem = 0x002F,
        /// <summary>
        /// An application sends a WM_SetFont message to specify the font that a control is to use when drawing text. 
        /// </summary>
        SetFont = 0x0030,
        /// <summary>
        /// An application sends a WM_GetFont message to a control to retrieve the font with which the control is currently drawing its text. 
        /// </summary>
        GetFont = 0x0031,
        /// <summary>
        /// An application sends a WM_SetHotKey message to a window to associate a hot key with the window. When the user presses the hot key, the system activates the window. 
        /// </summary>
        SetHotKey = 0x0032,
        /// <summary>
        /// An application sends a WM_GetHotKey message to determine the hot key associated with a window. 
        /// </summary>
        GetHotKey = 0x0033,
        /// <summary>
        /// The WM_QueryDragIcon message is sent to a minimized (iconic) window. The window is about to be dragged by the user but does not have an icon defined for its class. An application can return a handle to an icon or cursor. The system displays this cursor or icon while the user drags the icon.
        /// </summary>
        QueryDragIcon = 0x0037,
        /// <summary>
        /// The system sends the WM_CompareItem message to determine the relative position of a new item in the sorted list of an owner-drawn combo box or list box. Whenever the application adds a new item, the system sends this message to the owner of a combo box or list box created with the CBS_SORT or LBS_SORT style. 
        /// </summary>
        CompareItem = 0x0039,
        /// <summary>
        /// Active Accessibility sends the WM_GetObject message to obtain information about an accessible object contained in a server application. 
        /// Applications never send this message directly. It is sent only by Active Accessibility in response to calls to AccessibleObjectFromPoint, AccessibleObjectFromEvent, or AccessibleObjectFromWindow. However, server applications handle this message. 
        /// </summary>
        GetObject = 0x003D,
        /// <summary>
        /// The WM_Compacting message is sent to all top-level windows when the system detects more than 12.5 percent of system time over a 30- to 60-second interval is being spent compacting memory. This indicates that system memory is low.
        /// </summary>
        Compacting = 0x0041,
        /// <summary>
        /// WM_COMMNotify is Obsolete for Win32-Based Applications
        /// </summary>
        [Obsolete("This property is obsolete and will be removed in a future version.")]
        COMMNotify = 0x0044,
        /// <summary>
        /// The WM_WindowPosChanging message is sent to a window whose Size, position, or place in the Z order is about to change as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WindowPosChanging = 0x0046,
        /// <summary>
        /// The WM_WindowPosChanged message is sent to a window whose Size, position, or place in the Z order has changed as a result of a call to the SetWindowPos function or another window-management function.
        /// </summary>
        WindowPosChanged = 0x0047,
        /// <summary>
        /// Notifies applications that the system, typically a battery-powered personal computer, is about to enter a suspended mode.
        /// Use: PowerBroadcast
        /// </summary>
        [Obsolete("This property is obsolete and will be removed in a future version.")]
        Power = 0x0048,
        /// <summary>
        /// An application sends the WM_CopyData message to pass data to another application. 
        /// </summary>
        CopyData = 0x004A,
        /// <summary>
        /// The WM_CancelJournal message is posted to an application when a user cancels the application's journaling activities. The message is posted with a NULL window handle. 
        /// </summary>
        CancelJournal = 0x004B,
        /// <summary>
        /// Sent by a common control to its parent window when an event has occurred or the control requires some information. 
        /// </summary>
        Notify = 0x004E,
        /// <summary>
        /// The WM_InputLangChangeRequest message is posted to the window with the focus when the user chooses a new input language, either with the hotkey (specified in the Keyboard control panel application) or from the indicator on the system taskbar. An application can accept the change by passing the message to the DefWindowProc function or reject the change (and prevent it from taking place) by returning immediately. 
        /// </summary>
        InputLangChangeRequest = 0x0050,
        /// <summary>
        /// The WM_InputLangChange message is sent to the topmost affected window after an application's input language has been changed. You should make any application-specific settings and pass the message to the DefWindowProc function, which passes the message to all first-level child windows. These child windows can pass the message to DefWindowProc to have it pass the message to their child windows, and so on. 
        /// </summary>
        InputLangChange = 0x0051,
        /// <summary>
        /// Sent to an application that has initiated a training card with Microsoft Windows Help. The message informs the application when the user clicks an authorable button. An application initiates a training card by specifying the Help_TCard command in a call to the WinHelp function.
        /// </summary>
        TCard = 0x0052,
        /// <summary>
        /// Indicates that the user pressed the F1 key. If a menu is active when F1 is pressed, WM_Help is sent to the window associated with the menu; otherwise, WM_Help is sent to the window that has the keyboard focus. If no window has the keyboard focus, WM_Help is sent to the currently active window. 
        /// </summary>
        Help = 0x0053,
        /// <summary>
        /// The WM_UserChanged message is sent to all windows after the user has logged on or off. When the user logs on or off, the system updates the user-specific settings. The system sends this message immediately after updating the settings.
        /// </summary>
        UserChanged = 0x0054,
        /// <summary>
        /// Determines if a window accepts ANSI or Unicode structures in the WM_Notify notification message. WM_NotifyFormat messages are sent from a common control to its parent window and from the parent window to the common control.
        /// </summary>
        NotifyFormat = 0x0055,
        /// <summary>
        /// The WM_ContextMenu message notifies a window that the user clicked the right Mouse button (right-clicked) in the window.
        /// </summary>
        ContextMenu = 0x007B,
        /// <summary>
        /// The WM_StyleChanging message is sent to a window when the SetWindowLong function is about to change one or more of the window's styles.
        /// </summary>
        StyleChanging = 0x007C,
        /// <summary>
        /// The WM_StyleChanged message is sent to a window after the SetWindowLong function has changed one or more of the window's styles
        /// </summary>
        StyleChanged = 0x007D,
        /// <summary>
        /// The WM_DisplayChange message is sent to all windows when the display resolution has changed.
        /// </summary>
        DisplayChange = 0x007E,
        /// <summary>
        /// The WM_GetIcon message is sent to a window to retrieve a handle to the large or small icon associated with a window. The system displays the large icon in the ALT+TAB dialog, and the small icon in the window caption. 
        /// </summary>
        GetIcon = 0x007F,
        /// <summary>
        /// An application sends the WM_SetIcon message to associate a new large or small icon with a window. The system displays the large icon in the ALT+TAB dialog box, and the small icon in the window caption. 
        /// </summary>
        SetIcon = 0x0080,
        /// <summary>
        /// The WM_NCCreate message is sent prior to the WM_Create message when a window is first created.
        /// </summary>
        NCCreate = 0x0081,
        /// <summary>
        /// The WM_NCDestroy message informs a window that its nonclient area is being destroyed. The DestroyWindow function sends the WM_NCDestroy message to the window following the WM_Destroy message. WM_Destroy is used to free the allocated memory object associated with the window. 
        /// The WM_NCDestroy message is sent after the child windows have been destroyed. In contrast, WM_Destroy is sent before the child windows are destroyed.
        /// </summary>
        NCDestroy = 0x0082,
        /// <summary>
        /// The WM_NCCalcSize message is sent when the Size and position of a window's client area must be calculated. By processing this message, an application can control the content of the window's client area when the Size or position of the window changes.
        /// </summary>
        NCCalcSize = 0x0083,
        /// <summary>
        /// The WM_NCHITTEST message is sent to a window when the cursor moves, or when a Mouse button is pressed or released. If the Mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the Mouse.
        /// </summary>
        NCHitTest = 0x0084,
        /// <summary>
        /// The WM_NCPaint message is sent to a window when its frame must be painted. 
        /// </summary>
        NCPaint = 0x0085,
        /// <summary>
        /// The WM_NCActivate message is sent to a window when its nonclient area needs to be changed to indicate an active or inactive state.
        /// </summary>
        NCActivate = 0x0086,
        /// <summary>
        /// The WM_GetDlgCode message is sent to the window procedure associated with a control. By default, the system handles all keyboard input to the control; the system interprets certain types of keyboard input as dialog box navigation keys. To override this default behavior, the control can respond to the WM_GetDlgCode message to indicate the types of input it wants to process itself.
        /// </summary>
        GetDlgCode = 0x0087,
        /// <summary>
        /// The WM_SyncPaint message is used to synchronize painting while avoiding linking independent GUI threads.
        /// </summary>
        SyncPaint = 0x0088,
        /// <summary>
        /// The WM_NCMouseMove message is posted to a window when the cursor is moved within the nonclient area of the window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientMouseMove = 0x00A0,
        /// <summary>
        /// The WM_NCLButtonDown message is posted when the user presses the left Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientLButtonDown = 0x00A1,
        /// <summary>
        /// The WM_NCLButtonUp message is posted when the user releases the left Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientLButtonUp = 0x00A2,
        /// <summary>
        /// The WM_NCLButtonDblClk message is posted when the user double-clicks the left Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientLButtonDblClk = 0x00A3,
        /// <summary>
        /// The WM_NCrButtonDown message is posted when the user presses the right Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientRButtonDown = 0x00A4,
        /// <summary>
        /// The WM_NCrButtonUp message is posted when the user releases the right Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientRButtonUp = 0x00A5,
        /// <summary>
        /// The WM_NCrButtonDblClk message is posted when the user double-clicks the right Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientRButtonDblClk = 0x00A6,
        /// <summary>
        /// The WM_NCmButtonDown message is posted when the user presses the middle Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientMButtonDown = 0x00A7,
        /// <summary>
        /// The WM_NCmButtonUp message is posted when the user releases the middle Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientMButtonUp = 0x00A8,
        /// <summary>
        /// The WM_NCmButtonDblClk message is posted when the user double-clicks the middle Mouse button while the cursor is within the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientMButtonDblClk = 0x00A9,
        /// <summary>
        /// The WM_NCxButtonDown message is posted when the user presses the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientXButtonDown = 0x00AB,
        /// <summary>
        /// The WM_NCxButtonUp message is posted when the user releases the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientXButtonUp = 0x00AC,
        /// <summary>
        /// The WM_NCxButtonDblClk message is posted when the user double-clicks the first or second X button while the cursor is in the nonclient area of a window. This message is posted to the window that contains the cursor. If a window has captured the Mouse, this message is not posted.
        /// </summary>
        NonClientXButtonDblClk = 0x00AD,
        /// <summary>
        /// The WM_Input_Device_Change message is sent to the window that registered to receive raw input. A window receives this message through its WindowProc function.
        /// </summary>
        InputDeviceChange = 0x00FE,
        /// <summary>
        /// The WM_Input message is sent to the window that is getting raw input. 
        /// </summary>
        Input = 0x00FF,
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        KeyFirst = 0x0100,
        /// <summary>
        /// The WM_KeyDown message is posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem key is a key that is pressed when the ALT key is not pressed. 
        /// </summary>
        KeyDown = 0x0100,
        /// <summary>
        /// The WM_KeyUp message is posted to the window with the keyboard focus when a nonsystem key is released. A nonsystem key is a key that is pressed when the ALT key is not pressed, or a keyboard key that is pressed when a window has the keyboard focus. 
        /// </summary>
        KeyUp = 0x0101,
        /// <summary>
        /// The WM_Char message is posted to the window with the keyboard focus when a WM_KeyDown message is translated by the TranslateMessage function. The WM_Char message contains the character code of the key that was pressed. 
        /// </summary>
        Char = 0x0102,
        /// <summary>
        /// The WM_DeadChar message is posted to the window with the keyboard focus when a WM_KeyUp message is translated by the TranslateMessage function. WM_DeadChar specifies a character code generated by a dead key. A dead key is a key that generates a character, such as the umlaut (double-dot), that is combined with another character to form a composite character. For example, the umlaut-O character (Ö) is generated by typing the dead key for the umlaut character, and then typing the O key. 
        /// </summary>
        DeadChar = 0x0103,
        /// <summary>
        /// The WM_SysKeyDown message is posted to the window with the keyboard focus when the user presses the F10 key (which activates the menu bar) or holds down the ALT key and then presses another key. It also occurs when no window currently has the keyboard focus; in this case, the WM_SysKeyDown message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
        /// </summary>
        SysKeyDown = 0x0104,
        /// <summary>
        /// The WM_SysKeyUp message is posted to the window with the keyboard focus when the user releases a key that was pressed while the ALT key was held down. It also occurs when no window currently has the keyboard focus; in this case, the WM_SysKeyUp message is sent to the active window. The window that receives the message can distinguish between these two contexts by checking the context code in the lParam parameter. 
        /// </summary>
        SysKeyUp = 0x0105,
        /// <summary>
        /// The WM_SysChar message is posted to the window with the keyboard focus when a WM_SysKeyDown message is translated by the TranslateMessage function. It specifies the character code of a system character key — that is, a character key that is pressed while the ALT key is down. 
        /// </summary>
        SysChar = 0x0106,
        /// <summary>
        /// The WM_SysDeadChar message is sent to the window with the keyboard focus when a WM_SysKeyDown message is translated by the TranslateMessage function. WM_SysDeadChar specifies the character code of a system dead key — that is, a dead key that is pressed while holding down the ALT key. 
        /// </summary>
        SysDeadChar = 0x0107,
        /// <summary>
        /// The WM_UNIChar message is posted to the window with the keyboard focus when a WM_KeyDown message is translated by the TranslateMessage function. The WM_UNIChar message contains the character code of the key that was pressed. 
        /// The WM_UNIChar message is equivalent to WM_Char, but it uses Unicode Transformation Format (UTF)-32, whereas WM_Char uses UTF-16. It is designed to send or post Unicode characters to ANSI windows and it can can handle Unicode Supplementary Plane characters.
        /// </summary>
        UniChar = 0x0109,
        /// <summary>
        /// This message filters for keyboard messages.
        /// </summary>
        KeyLast = 0x0108,
        /// <summary>
        /// Sent immediately before the Ime generates the composition string as a result of a keystroke. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeStartComposition = 0x010D,
        /// <summary>
        /// Sent to an application when the Ime ends composition. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeEndComposition = 0x010E,
        /// <summary>
        /// Sent to an application when the Ime changes composition status as a result of a keystroke. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeComposition = 0x010F,
        ImeKeyLast = 0x010F,
        /// <summary>
        /// The WM_InitDialog message is sent to the dialog box procedure immediately before a dialog box is displayed. Dialog box procedures typically use this message to initialize controls and carry out any other initialization tasks that affect the appearance of the dialog box. 
        /// </summary>
        InitDialog = 0x0110,
        /// <summary>
        /// The WM_Command message is sent when the user selects a command item from a menu, when a control sends a notification message to its parent window, or when an accelerator keystroke is translated. 
        /// </summary>
        Command = 0x0111,
        /// <summary>
        /// A window receives this message when the user chooses a command from the Window menu, clicks the maximize button, minimize button, restore button, close button, or moves the form. You can stop the form from moving by filtering this out.
        /// </summary>
        SysCommand = 0x0112,
        /// <summary>
        /// The WM_Timer message is posted to the installing thread's message queue when a timer expires. The message is posted by the GetMessage or PeekMessage function. 
        /// </summary>
        Timer = 0x0113,
        /// <summary>
        /// The WM_HScroll message is sent to a window when a scroll event occurs in the window's standard horizontal scroll bar. This message is also sent to the owner of a horizontal scroll bar control when a scroll event occurs in the control. 
        /// </summary>
        HScroll = 0x0114,
        /// <summary>
        /// The WM_VScroll message is sent to a window when a scroll event occurs in the window's standard vertical scroll bar. This message is also sent to the owner of a vertical scroll bar control when a scroll event occurs in the control. 
        /// </summary>
        VScroll = 0x0115,
        /// <summary>
        /// The WM_InitMenu message is sent when a menu is about to become active. It occurs when the user clicks an item on the menu bar or presses a menu key. This allows the application to modify the menu before it is displayed. 
        /// </summary>
        InitMenu = 0x0116,
        /// <summary>
        /// The WM_InitMenupOPUp message is sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu. 
        /// </summary>
        InitMenupOPUp = 0x0117,
        /// <summary>
        /// The WM_MenuSelect message is sent to a menu's owner window when the user selects a menu item. 
        /// </summary>
        MenuSelect = 0x011F,
        /// <summary>
        /// The WM_MenuChar message is sent when a menu is active and the user presses a key that does not correspond to any mnemonic or accelerator key. This message is sent to the window that owns the menu. 
        /// </summary>
        MenuChar = 0x0120,
        /// <summary>
        /// The WM_EnterIDLE message is sent to the owner window of a modal dialog box or menu that is entering an idle state. A modal dialog box or menu enters an idle state when no messages are waiting in its queue after it has processed one or more previous messages. 
        /// </summary>
        EnterIdle = 0x0121,
        /// <summary>
        /// The WM_MenuRButtonUp message is sent when the user releases the right Mouse button while the cursor is on a menu item. 
        /// </summary>
        MenuRButtonUp = 0x0122,
        /// <summary>
        /// The WM_MenuDrag message is sent to the owner of a drag-and-drop menu when the user drags a menu item. 
        /// </summary>
        MenuDrag = 0x0123,
        /// <summary>
        /// The WM_MenuGetObject message is sent to the owner of a drag-and-drop menu when the Mouse cursor enters a menu item or moves from the center of the item to the top or bottom of the item. 
        /// </summary>
        MenuGetObject = 0x0124,
        /// <summary>
        /// The WM_UNInitMenupOPUp message is sent when a drop-down menu or submenu has been destroyed. 
        /// </summary>
        UNInitMenupOPUp = 0x0125,
        /// <summary>
        /// The WM_MenuCommand message is sent when the user makes a selection from a menu. 
        /// </summary>
        MenuCommand = 0x0126,
        /// <summary>
        /// An application sends the WM_ChangeUIState message to indicate that the user interface (UI) state should be changed.
        /// </summary>
        ChangeUIState = 0x0127,
        /// <summary>
        /// An application sends the WM_UpDateUIState message to change the user interface (UI) state for the specified window and all its child windows.
        /// </summary>
        UpDateUIState = 0x0128,
        /// <summary>
        /// An application sends the WM_QueryUIState message to retrieve the user interface (UI) state for a window.
        /// </summary>
        QueryUIState = 0x0129,
        /// <summary>
        /// The WM_CtlColorMsgBox message is sent to the owner window of a message box before Windows draws the message box. By responding to this message, the owner window can set the text and background colors of the message box by using the given display device context handle. 
        /// </summary>
        CtlColorMsgBox = 0x0132,
        /// <summary>
        /// An edit control that is not read-only or disabled sends the WM_CtlColorEdit message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the edit control. 
        /// </summary>
        CtlColorEdit = 0x0133,
        /// <summary>
        /// Sent to the parent window of a list box before the system draws the list box. By responding to this message, the parent window can set the text and background colors of the list box by using the specified display device context handle. 
        /// </summary>
        CtlColorListBox = 0x0134,
        /// <summary>
        /// The WM_CtlColorBtn message is sent to the parent window of a button before drawing the button. The parent window can change the button's text and background colors. However, only owner-drawn buttons respond to the parent window processing this message. 
        /// </summary>
        CtlColorBtn = 0x0135,
        /// <summary>
        /// The WM_CtlColorDlg message is sent to a dialog box before the system draws the dialog box. By responding to this message, the dialog box can set its text and background colors using the specified display device context handle. 
        /// </summary>
        CtlColorDlg = 0x0136,
        /// <summary>
        /// The WM_CtlColorScrollbar message is sent to the parent window of a scroll bar control when the control is about to be drawn. By responding to this message, the parent window can use the display context handle to set the background color of the scroll bar control. 
        /// </summary>
        CtlColorScrollBar = 0x0137,
        /// <summary>
        /// A static control, or an edit control that is read-only or disabled, sends the WM_CtlColorStatic message to its parent window when the control is about to be drawn. By responding to this message, the parent window can use the specified device context handle to set the text and background colors of the static control. 
        /// </summary>
        CtlColorStatic = 0x0138,
        /// <summary>
        /// Use WM_MouseFirst to specify the first Mouse message. Use the PeekMessage() Function.
        /// </summary>
        MouseFirst = 0x0200,
        /// <summary>
        /// The WM_MouseMove message is posted to a window when the cursor moves. If the Mouse is not captured, the message is posted to the window that contains the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        MouseMove = 0x0200,
        /// <summary>
        /// The WM_LButtonDown message is posted when the user presses the left Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        LButtonDown = 0x0201,
        /// <summary>
        /// The WM_LButtonUp message is posted when the user releases the left Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        LButtonUp = 0x0202,
        /// <summary>
        /// The WM_LButtonDblClk message is posted when the user double-clicks the left Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        LButtonDblClk = 0x0203,
        /// <summary>
        /// The WM_RButtonDown message is posted when the user presses the right Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        RButtonDown = 0x0204,
        /// <summary>
        /// The WM_RButtonUp message is posted when the user releases the right Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        RButtonUp = 0x0205,
        /// <summary>
        /// The WM_RButtonDblClk message is posted when the user double-clicks the right Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        RButtonDblClk = 0x0206,
        /// <summary>
        /// The WM_MButtonDown message is posted when the user presses the middle Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        MButtonDown = 0x0207,
        /// <summary>
        /// The WM_MButtonUp message is posted when the user releases the middle Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        MButtonUp = 0x0208,
        /// <summary>
        /// The WM_MButtonDblClk message is posted when the user double-clicks the middle Mouse button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        MButtonDblClk = 0x0209,
        /// <summary>
        /// The WM_MouseWheel message is sent to the focus window when the Mouse wheel is rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        MouseWheel = 0x020A,
        /// <summary>
        /// The WM_XButtonDown message is posted when the user presses the first or second X button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse. 
        /// </summary>
        XButtonDown = 0x020B,
        /// <summary>
        /// The WM_XButtonUp message is posted when the user releases the first or second X button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        XButtonUp = 0x020C,
        /// <summary>
        /// The WM_XButtonDblClk message is posted when the user double-clicks the first or second X button while the cursor is in the client area of a window. If the Mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the Mouse.
        /// </summary>
        XButtonDblClk = 0x020D,
        /// <summary>
        /// The WM_MouseHWheel message is sent to the focus window when the Mouse's horizontal scroll wheel is tilted or rotated. The DefWindowProc function propagates the message to the window's parent. There should be no internal forwarding of the message, since DefWindowProc propagates it up the parent chain until it finds a window that processes it.
        /// </summary>
        MouseHWheel = 0x020E,
        /// <summary>
        /// Use WM_MouseLast to specify the last Mouse message. Used with PeekMessage() Function.
        /// </summary>
        MouseLast = 0x020E,
        /// <summary>
        /// The WM_ParentNotify message is sent to the parent of a child window when the child window is created or destroyed, or when the user clicks a Mouse button while the cursor is over the child window. When the child window is being created, the system sends WM_ParentNotify just before the CreateWindow or CreateWindowEx function that creates the window returns. When the child window is being destroyed, the system sends the message before any processing to destroy the window takes place.
        /// </summary>
        ParentNotify = 0x0210,
        /// <summary>
        /// The WM_EnterMenuLoop message informs an application's main window procedure that a menu modal loop has been entered. 
        /// </summary>
        EnterMenuLoop = 0x0211,
        /// <summary>
        /// The WM_ExitMenuLoop message informs an application's main window procedure that a menu modal loop has been exited. 
        /// </summary>
        ExitMenuLoop = 0x0212,
        /// <summary>
        /// The WM_NextMenu message is sent to an application when the right or left arrow key is used to switch between the menu bar and the system menu. 
        /// </summary>
        NextMenu = 0x0213,
        /// <summary>
        /// The WM_Sizing message is sent to a window that the user is resizing. By processing this message, an application can monitor the Size and position of the drag rectangle and, if needed, change its Size or position. 
        /// </summary>
        Sizing = 0x0214,
        /// <summary>
        /// The WM_CaptureChanged message is sent to the window that is losing the Mouse capture.
        /// </summary>
        CaptureChanged = 0x0215,
        /// <summary>
        /// The WM_Moving message is sent to a window that the user is moving. By processing this message, an application can monitor the position of the drag rectangle and, if needed, change its position.
        /// </summary>
        Moving = 0x0216,
        /// <summary>
        /// Notifies applications that a power-management event has occurred.
        /// </summary>
        PowerBroadcast = 0x0218,
        /// <summary>
        /// Notifies an application of a change to the hardware configuration of a device or the computer.
        /// </summary>
        DeviceChange = 0x0219,
        /// <summary>
        /// An application sends the WM_MdiCreate message to a multiple-document interface (Mdi) client window to create an Mdi child window. 
        /// </summary>
        MdiCreate = 0x0220,
        /// <summary>
        /// An application sends the WM_MdiDestroy message to a multiple-document interface (Mdi) client window to close an Mdi child window. 
        /// </summary>
        MdiDestroy = 0x0221,
        /// <summary>
        /// An application sends the WM_MdiActivate message to a multiple-document interface (Mdi) client window to instruct the client window to activate a different Mdi child window. 
        /// </summary>
        MdiActivate = 0x0222,
        /// <summary>
        /// An application sends the WM_MdiRestore message to a multiple-document interface (Mdi) client window to restore an Mdi child window from maximized or minimized Size. 
        /// </summary>
        MdiRestore = 0x0223,
        /// <summary>
        /// An application sends the WM_MdiNext message to a multiple-document interface (Mdi) client window to activate the next or previous child window. 
        /// </summary>
        MdiNext = 0x0224,
        /// <summary>
        /// An application sends the WM_MdiMaximize message to a multiple-document interface (Mdi) client window to maximize an Mdi child window. The system reSizes the child window to make its client area fill the client window. The system places the child window's window menu icon in the rightmost position of the frame window's menu bar, and places the child window's restore icon in the leftmost position. The system also appends the title bar text of the child window to that of the frame window. 
        /// </summary>
        MdiMaximize = 0x0225,
        /// <summary>
        /// An application sends the WM_MdiTile message to a multiple-document interface (Mdi) client window to arrange all of its Mdi child windows in a tile format. 
        /// </summary>
        MdiTile = 0x0226,
        /// <summary>
        /// An application sends the WM_MdiCascade message to a multiple-document interface (Mdi) client window to arrange all its child windows in a cascade format. 
        /// </summary>
        MdiCascade = 0x0227,
        /// <summary>
        /// An application sends the WM_MdiIconArrange message to a multiple-document interface (Mdi) client window to arrange all minimized Mdi child windows. It does not affect child windows that are not minimized. 
        /// </summary>
        MdiIconArrange = 0x0228,
        /// <summary>
        /// An application sends the WM_MdiGetActive message to a multiple-document interface (Mdi) client window to retrieve the handle to the active Mdi child window. 
        /// </summary>
        MdiGetActive = 0x0229,
        /// <summary>
        /// An application sends the WM_MdiSetMenu message to a multiple-document interface (Mdi) client window to replace the entire menu of an Mdi frame window, to replace the window menu of the frame window, or both. 
        /// </summary>
        MdiSetMenu = 0x0230,
        /// <summary>
        /// The WM_EnterSizeMove message is sent one time to a window after it enters the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SysCommand message to the DefWindowProc function and the wParam parameter of the message specifies the SC_Move or SC_Size value. The operation is complete when DefWindowProc returns. 
        /// The system sends the WM_EnterSizeMove message regardless of whether the dragging of full windows is enabled.
        /// </summary>
        EnterSizeMove = 0x0231,
        /// <summary>
        /// The WM_ExitSizeMove message is sent one time to a window, after it has exited the moving or sizing modal loop. The window enters the moving or sizing modal loop when the user clicks the window's title bar or sizing border, or when the window passes the WM_SysCommand message to the DefWindowProc function and the wParam parameter of the message specifies the SC_Move or SC_Size value. The operation is complete when DefWindowProc returns. 
        /// </summary>
        ExitSizeMove = 0x0232,
        /// <summary>
        /// Sent when the user drops a file on the window of an application that has registered itself as a recipient of dropped files.
        /// </summary>
        DropFiles = 0x0233,
        /// <summary>
        /// An application sends the WM_MdiRefreshMenu message to a multiple-document interface (Mdi) client window to refresh the window menu of the Mdi frame window. 
        /// </summary>
        MdiRefreshMenu = 0x0234,
        /// <summary>
        /// Sent to an application when a window is activated. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeSetContext = 0x0281,
        /// <summary>
        /// Sent to an application to notify it of changes to the Ime window. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeNotify = 0x0282,
        /// <summary>
        /// Sent by an application to direct the Ime window to carry out the requested command. The application uses this message to control the Ime window that it has created. To send this message, the application calls the SendMessage function with the following parameters.
        /// </summary>
        ImeControl = 0x0283,
        /// <summary>
        /// Sent to an application when the Ime window finds no space to extend the area for the composition window. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeCompositionFull = 0x0284,
        /// <summary>
        /// Sent to an application when the operating system is about to change the current Ime. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeSelect = 0x0285,
        /// <summary>
        /// Sent to an application when the Ime gets a character of the conversion result. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeChar = 0x0286,
        /// <summary>
        /// Sent to an application to provide commands and request information. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeRequest = 0x0288,
        /// <summary>
        /// Sent to an application by the Ime to notify the application of a key press and to keep message order. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeKeyDown = 0x0290,
        /// <summary>
        /// Sent to an application by the Ime to notify the application of a key release and to keep message order. A window receives this message through its WindowProc function. 
        /// </summary>
        ImeKeyUp = 0x0291,
        /// <summary>
        /// The WM_MouseHover message is posted to a window when the cursor hovers over the client area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        MouseHover = 0x02A1,
        /// <summary>
        /// The WM_MouseLeave message is posted to a window when the cursor leaves the client area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        MouseLeave = 0x02A3,
        /// <summary>
        /// The WM_NCMouseHover message is posted to a window when the cursor hovers over the nonclient area of the window for the period of time specified in a prior call to TrackMouseEvent.
        /// </summary>
        NCMouseHover = 0x02A0,
        /// <summary>
        /// The WM_NCMouseLeave message is posted to a window when the cursor leaves the nonclient area of the window specified in a prior call to TrackMouseEvent.
        /// </summary>
        NCMouseLeave = 0x02A2,
        /// <summary>
        /// The WM_WTSSession_Change message notifies applications of changes in session state.
        /// </summary>
        WtsSessionChange = 0x02B1,
        TabletFirst = 0x02c0,
        TabletLast = 0x02df,
        /// <summary>
        /// An application sends a WM_Cut message to an edit control or combo box to delete (cut) the current selection, if any, in the edit control and copy the deleted text to the clipboard in CF_Text format. 
        /// </summary>
        Cut = 0x0300,
        /// <summary>
        /// An application sends the WM_Copy message to an edit control or combo box to copy the current selection to the clipboard in CF_Text format. 
        /// </summary>
        Copy = 0x0301,
        /// <summary>
        /// An application sends a WM_Paste message to an edit control or combo box to copy the current content of the clipboard to the edit control at the current caret position. Data is inserted only if the clipboard contains data in CF_Text format. 
        /// </summary>
        Paste = 0x0302,
        /// <summary>
        /// An application sends a WM_Clear message to an edit control or combo box to delete (clear) the current selection, if any, from the edit control. 
        /// </summary>
        Clear = 0x0303,
        /// <summary>
        /// An application sends a WM_Undo message to an edit control to undo the last operation. When this message is sent to an edit control, the previously deleted text is restored or the previously added text is deleted.
        /// </summary>
        Undo = 0x0304,
        /// <summary>
        /// The WM_RenderFormat message is sent to the clipboard owner if it has delayed rendering a specific clipboard format and if an application has requested data in that format. The clipboard owner must render data in the specified format and place it on the clipboard by calling the SetClipboardData function. 
        /// </summary>
        RenderFormat = 0x0305,
        /// <summary>
        /// The WM_RenderALLFormatS message is sent to the clipboard owner before it is destroyed, if the clipboard owner has delayed rendering one or more clipboard formats. For the content of the clipboard to remain available to other applications, the clipboard owner must render data in all the formats it is capable of generating, and place the data on the clipboard by calling the SetClipboardData function. 
        /// </summary>
        RenderAllFormats = 0x0306,
        /// <summary>
        /// The WM_DestroyClipboard message is sent to the clipboard owner when a call to the EmptyClipboard function empties the clipboard. 
        /// </summary>
        DestroyClipboard = 0x0307,
        /// <summary>
        /// The WM_DrawClipboard message is sent to the first window in the clipboard viewer chain when the content of the clipboard changes. This enables a clipboard viewer window to display the new content of the clipboard. 
        /// </summary>
        DrawClipboard = 0x0308,
        /// <summary>
        /// The WM_PaintClipboard message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDisplay format and the clipboard viewer's client area needs repainting. 
        /// </summary>
        PaintClipboard = 0x0309,
        /// <summary>
        /// The WM_VScrollClipboard message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDisplay format and an event occurs in the clipboard viewer's vertical scroll bar. The owner should scroll the clipboard image and update the scroll bar values. 
        /// </summary>
        VScrollClipboard = 0x030A,
        /// <summary>
        /// The WM_SizeClipboard message is sent to the clipboard owner by a clipboard viewer window when the clipboard contains data in the CF_OWNERDisplay format and the clipboard viewer's client area has changed Size. 
        /// </summary>
        SizeClipboard = 0x030B,
        /// <summary>
        /// The WM_AskCBFormatName message is sent to the clipboard owner by a clipboard viewer window to request the name of a CF_OWNERDisplay clipboard format.
        /// </summary>
        AskCBFormatName = 0x030C,
        /// <summary>
        /// The WM_ChangeCBChain message is sent to the first window in the clipboard viewer chain when a window is being removed from the chain. 
        /// </summary>
        ChangeCBChain = 0x030D,
        /// <summary>
        /// The WM_HScrollClipboard message is sent to the clipboard owner by a clipboard viewer window. This occurs when the clipboard contains data in the CF_OWNERDisplay format and an event occurs in the clipboard viewer's horizontal scroll bar. The owner should scroll the clipboard image and update the scroll bar values. 
        /// </summary>
        HScrollClipboard = 0x030E,
        /// <summary>
        /// This message informs a window that it is about to receive the keyboard focus, giving the window the opportunity to realize its logical palette when it receives the focus. 
        /// </summary>
        QueryNewPalette = 0x030F,
        /// <summary>
        /// The WM_PaletteISChanging message informs applications that an application is going to realize its logical palette. 
        /// </summary>
        PaletteIsChanging = 0x0310,
        /// <summary>
        /// This message is sent by the OS to all top-level and overlapped windows after the window with the keyboard focus realizes its logical palette. 
        /// This message enables windows that do not have the keyboard focus to realize their logical palettes and update their client areas.
        /// </summary>
        PaletteChanged = 0x0311,
        /// <summary>
        /// The WM_HotKey message is posted when the user presses a hot key registered by the RegisterHotKey function. The message is placed at the top of the message queue associated with the thread that registered the hot key. 
        /// </summary>
        HotKey = 0x0312,
        /// <summary>
        /// The WM_Print message is sent to a window to request that it draw itself in the specified device context, most commonly in a printer device context.
        /// </summary>
        Print = 0x0317,
        /// <summary>
        /// The WM_PrintClient message is sent to a window to request that it draw its client area in the specified device context, most commonly in a printer device context.
        /// </summary>
        PrintClient = 0x0318,
        /// <summary>
        /// The WM_AppCommand message notifies a window that the user generated an application command event, for example, by clicking an application command button using the Mouse or typing an application command key on the keyboard.
        /// </summary>
        AppCommand = 0x0319,
        /// <summary>
        /// The WM_ThemeChanged message is broadcast to every window following a theme change event. Examples of theme change events are the activation of a theme, the deactivation of a theme, or a transition from one theme to another.
        /// </summary>
        ThemeChanged = 0x031A,
        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        ClipboardUpDate = 0x031D,
        /// <summary>
        /// The system will send a window the WM_DwmCompositionChanged message to indicate that the availability of desktop composition has changed.
        /// </summary>
        DwmCompositionChanged = 0x031E,
        /// <summary>
        /// WM_DwmNCRenderingChanged is called when the non-client area rendering status of a window has changed. Only windows that have set the flag Dwm_BLURBEHIND.fTransitionOnMaximized to true will get this message. 
        /// </summary>
        DwmNCRenderingChanged = 0x031F,
        /// <summary>
        /// Sent to all top-level windows when the colorization color has changed. 
        /// </summary>
        DwmColorizationColorChanged = 0x0320,
        /// <summary>
        /// WM_DwmWindowMaximizedChange will let you know when a Dwm composed window is maximized. You also have to register for this message as well. You'd have other windowd go opaque when this message is sent.
        /// </summary>
        DwmWindowMaximizedChange = 0x0321,
        /// <summary>
        /// Sent to request extended title bar information. A window receives this message through its WindowProc function.
        /// </summary>
        GetTitleBarInfoEX = 0x033F,
        HandHeldFirst = 0x0358,
        HandHeldLast = 0x035F,
        AfxFirst = 0x0360,
        AfxLast = 0x037F,
        PenWinFirst = 0x0380,
        PenWinLast = 0x038F,
        /// <summary>
        /// The WM_App constant is used by applications to help define private messages, usually of the form WM_App+X, where X is an integer value. 
        /// </summary>
        App = 0x8000,
        /// <summary>
        /// The WM_User constant is used by applications to help define private messages for use by private window classes, usually of the form WM_User+X, where X is an integer value. 
        /// </summary>
        User = 0x0400,

        /// <summary>
        /// An application sends the WM_CplLaunch message to Windows Control Panel to request that a Control Panel application be started. 
        /// </summary>
        CplLaunch = User + 0x1000,
        /// <summary>
        /// The WM_CplLaunched message is sent when a Control Panel application, started by the WM_CplLaunch message, has closed. The WM_CplLaunched message is sent to the window identified by the wParam parameter of the WM_CplLaunch message that started the application. 
        /// </summary>
        CplLaunched = User + 0x1001,
        /// <summary>
        /// WM_SysTimer is a well-known yet still undocumented message. Windows uses WM_SysTimer for internal actions like scrolling.
        /// </summary>
        SysTimer = 0x118,

        /// <summary>
        /// The accessibility state has changed.
        /// </summary>
        HShellAccessibilityState = 11,
        /// <summary>
        /// The shell should activate its main window.
        /// </summary>
        HShellActivateShellWindow = 3,
        /// <summary>
        /// The user completed an input event (for example, pressed an application command button on the Mouse or an application command key on the keyboard), and the application did not handle the WM_AppCommand message generated by that input.
        /// If the Shell procedure handles the WM_Command message, it should not call CallNextHookEx. See the Return Value section for more information.
        /// </summary>
        HShellAppCommand = 12,
        /// <summary>
        /// A window is being minimized or maximized. The system needs the coordinates of the minimized rectangle for the window.
        /// </summary>
        HShellGetMinRect = 5,
        /// <summary>
        /// Keyboard language was changed or a new keyboard layout was loaded.
        /// </summary>
        HShellLanguage = 8,
        /// <summary>
        /// The title of a window in the task bar has been redrawn.
        /// </summary>
        HShellRedraw = 6,
        /// <summary>
        /// The user has selected the task list. A shell application that provides a task list should return TRUE to prevent Windows from starting its task list.
        /// </summary>
        HShellTaskMan = 7,
        /// <summary>
        /// A top-level, unowned window has been created. The window exists when the system calls this hook.
        /// </summary>
        HShellWindowCreated = 1,
        /// <summary>
        /// A top-level, unowned window is about to be destroyed. The window still exists when the system calls this hook.
        /// </summary>
        HShellWindowDestroyed = 2,
        /// <summary>
        /// The activation has changed to a different top-level, unowned window.
        /// </summary>
        HShellWindowActivated = 4,
        /// <summary>
        /// A top-level window is being replaced. The window exists when the system calls this hook.
        /// </summary>
        HShellWindowReplaced = 13
    }
}
