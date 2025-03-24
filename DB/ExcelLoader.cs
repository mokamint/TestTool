using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClosedXML.Excel;

namespace TestTool.DB
{
    internal class ExcelLoader
    {
        public static void Load(string path)
        {
            var quizzes = new List<Quiz>();

            // Load excel file
            // stream을 이용해서 파일이 사용 중일때도 읽을 수 있도록 함
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var workbook = new XLWorkbook(stream))
            {
                var worksheet = workbook.Worksheets.First();
                var rows = worksheet.RowsUsed().Skip(1); // Skip header row

                foreach (var row in rows)
                {
                    var quiz = new Quiz
                    {
                        Id = row.Cell(1).GetValue<int>(),
                        Book = row.Cell(2).GetValue<string>(),
                        Category = new List<string>
                        {
                            row.Cell(3).GetValue<string>(),
                            row.Cell(4).GetValue<string>(),
                            row.Cell(5).GetValue<string>()
                        },
                        Question = row.Cell(6).GetValue<string>(),
                        Answer = row.Cell(7).GetValue<string>(),
                        Selection = new List<string>
                        {
                            row.Cell(8).GetValue<string>(),
                            row.Cell(9).GetValue<string>(),
                            row.Cell(10).GetValue<string>(),
                            row.Cell(11).GetValue<string>(),
                            row.Cell(12).GetValue<string>()
                        },
                        Difficulty = row.Cell(13).GetValue<string>(),
                        IsUsed = row.Cell(14).GetValue<string>()
                    };

                    quizzes.Add(quiz);
                }
            }

            QuizDB.QuizList = quizzes;
            MessageBox.Show("Load complete");
        }
    }
}
