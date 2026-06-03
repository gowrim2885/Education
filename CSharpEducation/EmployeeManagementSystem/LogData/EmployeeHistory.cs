using System;

using System.Text.Json;

using EmployeeManagementSystem.logic.services;
using EmployeeManagementSystem.Log;

namespace EmployeeManagementSystem.Log
{
    public class EmployeeHistory
    {
        public int HistoryId { get; set; }
        public int EmployeeId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public int Version { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
    }

    public class EmployeeHistoryStorage
    {
        private static string FilePath = "C:\\Gowri\\Repositories\\CSharpProject\\CSharpProjects\\EmployeeManagementSystem\\LogDetails.json";

        public static void SaveHistory(EmployeeHistory history)
        {
            List<EmployeeHistory> histories = new List<EmployeeHistory>();

            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);

                histories = JsonSerializer.Deserialize<List<EmployeeHistory>>(json)
                            ?? new List<EmployeeHistory>();
            }

            history.HistoryId = GetNextHistoryId(histories);
            history.Version = GetNextVersion(histories, history.EmployeeId);
            history.Timestamp = DateTime.Now;


            histories.Add(history);

            string updatedJson = JsonSerializer.Serialize(histories, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(FilePath, updatedJson);
        }
        private static int GetNextHistoryId(List<EmployeeHistory> histories)
        {
            if (histories.Count == 0)
                return 1;

            return histories.Max(h => h.HistoryId) + 1;
        }


        public static int GetNextVersion(List<EmployeeHistory> histories, int employeeId)
        {
            var employeeHistory = histories
                .Where(h => h.EmployeeId == employeeId)
                .ToList();

            if (employeeHistory.Count == 0)
                return 1;

            return employeeHistory.Max(h => h.Version) + 1;
        }
    }
}


    
