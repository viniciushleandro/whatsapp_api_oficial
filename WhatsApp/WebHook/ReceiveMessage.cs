using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebHook
{

    public class Metadata
    {
        public string DisplayPhoneNumber { get; set; }
        public string PhoneNumberId { get; set; }
    }

    public class Change
    {
        public string Field { get; set; }
        public Value Value { get; set; }
    }

    public class Entry
    {
        public string Id { get; set; }
        public List<Change> Changes { get; set; }
    }

    public class Value
    {
        public string MessagingProduct { get; set; }
        public Metadata Metadata { get; set; }
        // Adicione outras propriedades específicas do payload do webhook aqui
    }

    public class ReceiveMessage
    {
        public string Object { get; set; }
        public List<Entry> Entry { get; set; }
    }

}
