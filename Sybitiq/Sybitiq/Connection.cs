using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Sybitiq
{
    class Connection
    {
      
            OleDbCommand command;
            public List<string> ListboxItems = new List<string>();
            public List<int> ListboxItems1 = new List<int>();
            private OleDbConnection ConnectTo()
            {
                OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\1\\Desktop\\sybitiq1.accdb");
                command = connection.CreateCommand();
                connection.Open();
                return connection;
            }

          

        public void Insert(sybitiq p)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("INSERT INTO Sybitiq([sybitie], [grad], [tema], data, nachalenChas, kraenChas, mqsto, cena) VALUES" +
                     "(" + "'" + p.sybitie + "'" + "," + "'" + p.grad + "'" + "," + "'" + p.tema + "'" + "," + "#" + p.data.ToString("yyyy-MM-dd") + "#" + ","
                     + p.nachalenChas + "," + p.kraenChas + "," + p.mqsto + "," + p.cena + ")", connection);
                  
                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно въведено събитие!");
                }
                catch (Exception )
                {
                    MessageBox.Show("Некоректни данни");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Update(sybitiq p)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("Update Sybitiq Set sybitie=" + "'" + p.sybitie + "'" + "," + "grad=" + "'" + p.grad + "'" + "," + "tema=" +
                      "'" + p.tema + "'" + "," + " data=" + "#" + p.data.ToString("yyyy-MM-dd") + "#" + "," + "nachalenChas=" + p.nachalenChas + ","
                      + "kraenChas=" + p.kraenChas + "," + "mqsto=" + p.mqsto + "," + "cena=" + p.cena + " Where ID=" + p.ID, connection);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно редактирано събитие!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Некоректни данни");
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public void Delete(sybitiq p)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    command.CommandText = "Delete From Sybitiq Where ID=" + p.ID;
                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                    MessageBox.Show("Успешно изтрито събитие");
                }
                catch (Exception)
                {
                    //throw;
                    MessageBox.Show("Некоректни данни!");
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void pomalkaot30(List<sybitiq> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Sybitiq WHERE cena<30", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        sybitiq a = new sybitiq();
                        a.ID = reader.GetInt32(0);
                        a.sybitie = reader.GetString(1);
                        a.grad = reader.GetString(2);
                        a.tema = reader.GetString(3);
                        a.data = reader.GetDateTime(4);
                        a.nachalenChas = reader.GetInt32(5);
                        a.kraenChas = reader.GetInt32(6);
                        a.mqsto = reader.GetInt32(7);
                        a.cena = reader.GetInt32(8);

                        aktiviList.Add(a);

                    }
                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void pogolqmaot30(List<sybitiq> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Sybitiq WHERE cena>=30", connection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        sybitiq a = new sybitiq();
                        a.ID = reader.GetInt32(0);
                        a.sybitie = reader.GetString(1);
                        a.grad = reader.GetString(2);
                        a.tema = reader.GetString(3);
                        a.data = reader.GetDateTime(4);
                        a.nachalenChas = reader.GetInt32(5);
                        a.kraenChas = reader.GetInt32(6);
                        a.mqsto = reader.GetInt32(7);
                        a.cena = reader.GetInt32(8);

                        aktiviList.Add(a);
                    }

                    reader.Close();
                }


                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void sortirovkaime(List<sybitiq> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("Select * From Sybitiq ORDER BY sybitie ASC", connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        sybitiq a = new sybitiq();
                        a.ID = reader.GetInt32(0);
                        a.sybitie = reader.GetString(1);
                        a.grad = reader.GetString(2);
                        a.tema = reader.GetString(3);
                        a.data = reader.GetDateTime(4);
                        a.nachalenChas = reader.GetInt32(5);
                        a.kraenChas = reader.GetInt32(6);
                        a.mqsto = reader.GetInt32(7);
                        a.cena = reader.GetInt32(8);

                        aktiviList.Add(a);

                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void sortirovkagrad(List<sybitiq> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("Select * From Sybitiq ORDER BY grad ASC", connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        sybitiq a = new sybitiq();
                        a.ID = reader.GetInt32(0);
                        a.sybitie = reader.GetString(1);
                        a.grad = reader.GetString(2);
                        a.tema = reader.GetString(3);
                        a.data = reader.GetDateTime(4);
                        a.nachalenChas = reader.GetInt32(5);
                        a.kraenChas = reader.GetInt32(6);
                        a.mqsto = reader.GetInt32(7);
                        a.cena = reader.GetInt32(8);

                        aktiviList.Add(a);

                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void sortirovkanachalenchas(List<sybitiq> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("Select * From Sybitiq ORDER BY nachalenChas ASC", connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        sybitiq a = new sybitiq();
                        a.ID = reader.GetInt32(0);
                        a.sybitie = reader.GetString(1);
                        a.grad = reader.GetString(2);
                        a.tema = reader.GetString(3);
                        a.data = reader.GetDateTime(4);
                        a.nachalenChas = reader.GetInt32(5);
                        a.kraenChas = reader.GetInt32(6);
                        a.mqsto = reader.GetInt32(7);
                        a.cena = reader.GetInt32(8);

                        aktiviList.Add(a);

                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void sortirovkanakraenchas(List<sybitiq> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("Select * From Sybitiq ORDER BY kraenChas ASC", connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        sybitiq a = new sybitiq();
                        a.ID = reader.GetInt32(0);
                        a.sybitie = reader.GetString(1);
                        a.grad = reader.GetString(2);
                        a.tema = reader.GetString(3);
                        a.data = reader.GetDateTime(4);
                        a.nachalenChas = reader.GetInt32(5);
                        a.kraenChas = reader.GetInt32(6);
                        a.mqsto = reader.GetInt32(7);
                        a.cena = reader.GetInt32(8);

                        aktiviList.Add(a);

                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void sortirovkamqsto(List<mqsto> aktiviList)
        {
            using (OleDbConnection connection = ConnectTo())
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("Select * From Mqsto ORDER BY mеstopolojenie ASC", connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        mqsto a = new mqsto();
                        a.ID = reader.GetInt32(0);
                        a.mеstopolojenie = reader.GetString(1);

                        aktiviList.Add(a);

                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Грешка");
                }
                finally
                {
                    connection.Close();
                }

            }
        }






    }
    
}
