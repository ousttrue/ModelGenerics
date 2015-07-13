﻿using Livet.Messaging;
using Livet.Messaging.IO;
using NLog;
using System;
using System.Windows;

namespace WpfViewer.ViewModels
{
    class ViewModelBase: Livet.ViewModel
    {
        #region Logger
        protected static Logger Logger
        {
            get { return LogManager.GetCurrentClassLogger(); }
        }
        #endregion

        #region LivetMessage
        #region InformationMessage
        protected void InfoDialog(String message)
        {
            Messenger.Raise(new InformationMessage(message, "Info", MessageBoxImage.Information, "Info"));
        }

        protected void ErrorDialog(Exception ex)
        {
            Messenger.Raise(new InformationMessage(ex.Message, "Error", MessageBoxImage.Error, "Info"));
        }
        #endregion

        #region ConfirmationMessage
        protected bool ConfirmDialog(String text, String title)
        {
            var message = new ConfirmationMessage(text, title
                        , MessageBoxImage.Question, MessageBoxButton.YesNo, "Confirm");
            Messenger.Raise(message);
            return message.Response.HasValue && message.Response.Value;
        }
        #endregion

        #region OpeningFileSelectionMessage
        protected String[] OpenDialog(String title, bool multiSelect = false)
        {
            return OpenDialog(title, "すべてのファイル(*.*)|*.*", multiSelect);
        }
        protected String[] OpenDialog(String title, String filter = "すべてのファイル(*.*)|*.*", bool multiSelect = false)
        {
            var message = new OpeningFileSelectionMessage("Open")
            {
                Title = title,
                Filter = filter,
                MultiSelect = multiSelect,
            };
            Messenger.Raise(message);
            return message.Response;
        }
        #endregion

        #region SavingFileSelectionMessage
        protected String SaveDialog(String title, string filename)
        {
            var message = new SavingFileSelectionMessage("Save")
            {
                Title = title,
                FileName = String.IsNullOrEmpty(filename) ? "list.txt" : filename,
            };
            Messenger.Raise(message);
            return message.Response != null ? message.Response[0] : null;
        }
        #endregion
        #endregion


    }
}
