using Microsoft.Azure.Mobile.Server;

namespace SmartShop20180314112512Service.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}