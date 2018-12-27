namespace Hotel32.UI.Managers.Interfaces
{
    public interface IGridManager
    {
        void AddUserControl<T>(T userControl);
        void ClearMainGridFromUserControls();
        void AddStatusMessage(string value);
    }
}