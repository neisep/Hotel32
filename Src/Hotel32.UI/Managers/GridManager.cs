﻿using Hotel32.UI.Managers.Interfaces;
using Hotel32.UI.View;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Hotel32.UI.Managers
{
    public class GridManager : IGridManager
    {
        private Grid _mainGrid;
        public GridManager(Grid mainGrid)
        {
            _mainGrid = mainGrid;
        }

        public void AddUserControl<T>(T userControl)
        {
            if (userControl.GetType() == typeof(CustomerUserControl))
            {
                ClearMainGridFromUserControls();
                _mainGrid.Children.Add(userControl as CustomerUserControl);
            }
            else if(userControl.GetType() == typeof(CustomerEditUserControl))
            {
                ClearMainGridFromUserControls();
                _mainGrid.Children.Add(userControl as CustomerEditUserControl);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void ClearMainGridFromUserControls()
        {
            List<object> userControlsToRemove = new List<object>();

            foreach (var item in _mainGrid.Children)
            {
                if (item.GetType() == typeof(CustomerUserControl))
                {
                    userControlsToRemove.Add(item);
                }
                else if(item.GetType() == typeof(CustomerEditUserControl))
                {
                    userControlsToRemove.Add(item);
                }
            }
            foreach (var item in userControlsToRemove)
            {
                if (item.GetType() == typeof(CustomerUserControl))
                {
                    _mainGrid.Children.Remove(item as CustomerUserControl);
                }
                else if (item.GetType() == typeof(CustomerEditUserControl))
                {
                    _mainGrid.Children.Remove(item as CustomerEditUserControl);
                }
            }
        }

        //TODO Change this make use of enums of Warning, Danger etc maybe we should have a userConrol for it
        public void AddStatusMessage(string value)
        {
            TextBlock text = new TextBlock();
            text.SetValue(Grid.RowProperty, 1);
            text.Text = value;
            _mainGrid.Children.Add(text);
        }
    }
}
