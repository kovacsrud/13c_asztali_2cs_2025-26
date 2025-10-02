using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfKutyakDB.Mvvm.Model;
using System.Data.SQLite;
using System.Windows;

namespace WpfKutyakDB
{
    public static class DbRepo
    {
        public static List<Kutyanev> GetKutyanevek()
        {
            List<Kutyanev> kutyanevek=new List<Kutyanev>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string selectCommand = "select * from kutyanevek";
                    using (SQLiteCommand command=new SQLiteCommand(selectCommand,connection))
                    {
                        using (SQLiteDataReader reader=command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Kutyanev kutyanev = new Kutyanev
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    KutyaNev = reader["kutyanev"].ToString()
                                };

                                kutyanevek.Add(kutyanev);
                            }
                        }
                    }
                }

            }
            catch (SQLiteException ex) {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }

            return kutyanevek;
        }

        public static void UjKutyanev(Kutyanev kutyanev)
        {
            try
            {
                using (SQLiteConnection connection=new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string insertCommand = "insert into kutyanevek (kutyanev) values(@kutyanev)";
                    using (SQLiteCommand command=new SQLiteCommand(insertCommand,connection))
                    {
                        command.Parameters.AddWithValue("@kutyanev", kutyanev.KutyaNev);
                        var sorok=command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor beszúrva!");
                    }
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ModositKutyanev(Kutyanev kutyanev)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string updateCommand = "update kutyanevek set kutyanev=@kutyanev where Id=@id";
                    using (SQLiteCommand command = new SQLiteCommand(updateCommand, connection))
                    {
                        command.Parameters.AddWithValue("@kutyanev", kutyanev.KutyaNev);
                        command.Parameters.AddWithValue("@id", kutyanev.Id);

                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor módosítva!");
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void TorolKutyanev(Kutyanev kutyanev)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Config.connectionString))
                {
                    connection.Open();
                    string deleteCommand = "delete from kutyanevek where Id=@id";
                    using (SQLiteCommand command = new SQLiteCommand(deleteCommand, connection))
                    {
                        
                        command.Parameters.AddWithValue("@id", kutyanev.Id);

                        var sorok = command.ExecuteNonQuery();
                        MessageBox.Show($"{sorok} sor törölve!");
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Adatbázis hiba:{ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
