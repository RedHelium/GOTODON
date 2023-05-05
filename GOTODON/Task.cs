namespace GOTODON
{
    public enum TaskType : sbyte { TODO, InProgress, Complete }

    public sealed class Task
    {
        public string Message { get; set; }
        public object View { get; set; }
        public sbyte Type { get; set; }
    }
}
