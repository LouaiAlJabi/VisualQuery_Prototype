using System;
using System.Collections.Generic;
using System.Linq;
using Raylib_cs;
using Microsoft.Data.Sqlite; 

namespace VisualQuery_Prototype
{
    class VisualQuery
    {
        static void Main()
        {
            // Initialize Raylib window, should be big enough for a prototype 
            Raylib.InitWindow(800, 600, "VisualQuery");
            Raylib.SetTargetFPS(60);

            // MAKE A TABLE AND PARSE IT
            List<List<string>> dataTable = new List<List<string>>()
            {
                new List<string> { "ID", "Name", "Value" },
                new List<string> { "1", "Alice", "100" },
                new List<string> { "2", "Bob", "150" }
            };

            // Convert the list to DataTable for SQL querying
            var dataTableAsDataTable = ConvertToDataTable(dataTable);

            // open a connection to the sql parser
            using var connection = new SqliteConnection("Data Source=:memory:"); // Using Microsoft.Data.Sqlite
            connection.Open();

            // using the datatable to make an actual sql table
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE Data (ID TEXT, Name TEXT, Value TEXT)";
                command.ExecuteNonQuery();
                foreach (var row in dataTable.Skip(1)) // fuck header row
                {
                    command.CommandText = $"INSERT INTO Data (ID, Name, Value) VALUES ('{row[0]}', '{row[1]}', '{row[2]}')";
                    command.ExecuteNonQuery();
                }
            }

            // MAKE A TEXTBOX AND HANDLE IT
            string query = "";
            bool showCursor = true; // wanna see the mouse around
            while (!Raylib.WindowShouldClose())
            {
                
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            using (var reader = command.ExecuteReader())
                            {
                                dataTable.Clear();
                                var headers = new List<string>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    headers.Add(reader.GetName(i)); 
                                }
                                dataTable.Add(headers);

                                while (reader.Read())
                                {
                                    var row = new List<string>();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        row.Add(reader.GetValue(i).ToString());
                                    }
                                    dataTable.Add(row);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error executing query: " + ex.Message);
                    }
                }

                if (Raylib.IsKeyPressed(KeyboardKey.Backspace) && query.Length > 0)
                {
                    query = query.Remove(query.Length - 1);
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Space))
                {
                    query += " ";
                }
                else
                {
                    int key = Raylib.GetKeyPressed();
                    if (key > 0 && key < 128) // all ASCII printable characters, no special characters, didn't know how to do it
                    {
                        char c = (char)key;
                        if (char.IsLetterOrDigit(c) || c == '_' || c == ' ' || c == ';' || c == '*')
                        {
                            query += c;
                        }
                    }
                }

                // Draw the shit
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                // Draw table
                int startX = 50;
                int startY = 50;
                int cellWidth = 100;
                int cellHeight = 30;
                Raylib.DrawText("Table Name: Data", 20, 20, 20, Color.Black);
                foreach (var row in dataTable)
                {
                    int x = startX;
                    foreach (var cell in row)
                    {
                        Raylib.DrawRectangle(x, startY, cellWidth, cellHeight, Color.Gray);
                        Raylib.DrawText(cell, x + 5, startY + 5, 20, Color.Black);
                        x += cellWidth;
                    }
                    startY += cellHeight;
                }

                // Draw text box
                Raylib.DrawRectangle(50, Raylib.GetScreenHeight() - 70, 700, 65, Color.LightGray);
                Raylib.DrawText("Enter SQL Query:", 60, Raylib.GetScreenHeight() - 65, 20, Color.Black);
                Raylib.DrawText(query, 60, Raylib.GetScreenHeight() - 30, 20, Color.Black);

                Raylib.EndDrawing();
            }
        
            Raylib.CloseWindow();
        }

        static System.Data.DataTable ConvertToDataTable(List<List<string>> data) // make the table
        {
            var table = new System.Data.DataTable();

            if (data.Count > 0)
            {
                foreach (var column in data[0])
                {
                    table.Columns.Add(column);
                }

                for (int i = 1; i < data.Count; i++)
                {
                    table.Rows.Add(data[i].ToArray());
                }
            }
            return table;
        }
    }
}
