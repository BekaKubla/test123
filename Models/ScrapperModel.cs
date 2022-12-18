using System;
using System.ComponentModel;

namespace WebApplication5.Models
{
    public class ScrapperModel
    {
        public long Id { get; set; }
        [DisplayName("საიტის დასახელება")]
        public string WebSiteName { get; set; }
        [DisplayName("განცხადების ნომერი")]
        public string HouseId { get; set; }
        [DisplayName("კვ/მ")]
        public string SquareMeter { get; set; }
        [DisplayName("ფასი კვ/მ")]
        public string PriceOneSquareMeter { get; set; }
        [DisplayName("ფასი დოლარში")]
        public string PriceInUsd { get; set; }
        [DisplayName("მისამართი")]
        public string Address { get; set; }
        [DisplayName("განცხადების თარიღი")]
        public string CreateDate { get; set; }
        [DisplayName("განახლების თარიღი")]
        public DateTime JobCreate { get; set; }
        public DateTime InsideMethodTime { get; set; }
        public int StatementType { get; set; }

    }
    public enum StatementType
    {
        ბინა = 1,
        მიწა = 2
    }
}
