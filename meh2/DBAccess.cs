using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.Data;
using System.IO;

namespace meh2
{   // Класс для работы с БД
    public partial class DBAccess: Form1
    {
        // Переменные названия файлов, строки SQLiteCOnnection, Path, SQLiteCommand
        private String dbFileName;
        public SQLiteConnection m_dbConn;
        private SQLiteCommand m_sqlCmd;
        private string dbPath;

        public DBAccess()
        {
            
        }
        // При загрузке окна создаем объекты подключения и объект для комманд SQL
        private void Form1_Load(object sender, EventArgs e)
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();


            dbFileName = "DataResult.sqlite";
        }
        // Функция создания ДБ, если еще не создана и подключение к ней
        public void CreateDb()
        {
            m_dbConn = new SQLiteConnection();
            m_sqlCmd = new SQLiteCommand();

            
            dbFileName = "DataResult.sqlite";

            // Если еще не существует создаем новую ДБ
            if (!File.Exists(dbFileName))
                SQLiteConnection.CreateFile(dbFileName);
            // Оюработка исключений типа SQLiteException
            try
            {
                //Подключение к дб
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                // Создание двух полей Result и File
                m_sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS Catalog (Result INTEGER, File TEXT)";
                string relativePath = @"Debug\DataResult.sqlite";
                var parentdir = Path.GetDirectoryName(Application.StartupPath);
                string absolutePath = Path.Combine(parentdir, relativePath);
                dbPath = absolutePath;
                m_sqlCmd.ExecuteNonQuery();
            }

            catch (SQLiteException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }
        // Подключение к Дб если та уже создана
        public void connectDb()
        {
            try
            {
                //m_dbConn = new SQLiteConnection("data source=" + "{AppDir}/DATA/" + dbFileName + ";Version=3;");
                m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
            }
            catch (SQLiteException ex)
            { 
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Добавление данных результата работы программы(чисел армстронга)
        public void addData(int data)
        {
            // Обработка исключения на не подключеннную ДБ типа SQLiteException
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("DB Not Connected!");
                return;
            }

            try
            {
                m_sqlCmd.CommandText = "INSERT INTO Catalog('Result') VALUES('"+ data +"')";

                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        // Добавление пути в поле File
        public void addData2()
        {
            if (m_dbConn.State != ConnectionState.Open)
            {
                MessageBox.Show("DB Not Connected!");
                return;
            }
            try
            {
                m_sqlCmd.CommandText = "INSERT INTO Catalog('File') VALUES('" + dbPath + "')";
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       

    }

}
