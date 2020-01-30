using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask_V1336.Models
{
    public class Well //Класс скважины
    {
        public int Id { get; set; }             //ID
        public string Name { get; set; }        //Название
        public string Group { get; set; }       //Название группы скважин
        public string Field { get; set; }       //Название месторождения
        public string Factory { get; set; }     //Название цеха
        public int ControllerId { get; set; }   //Идентификатор контроллера
        public OperationTypeEnum OperationType { get; set; }        //Тип эксплуатации
        public enum OperationTypeEnum { ЭЦН = 1, ШГН = 2, ГПШГН = 3, ЭВН = 4 }   //Тип эксплуатации (перечисление)
    }
}