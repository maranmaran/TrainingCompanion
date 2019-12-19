using System;
using System.Collections.Generic;
using System.Text;
using Backend.Service.Excel.Models;

namespace Backend.Service.Excel.Interfaces
{
    public interface IExcelService
    {
        void ExportTraining(ExportTrainingContainer data);
    }

}
