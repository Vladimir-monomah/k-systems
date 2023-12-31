﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k_systems._k_systemsDataSetTableAdapters;
using static k_systems._k_systemsDataSet;
using System.Data.OleDb;
using System.Data;

namespace k_systems
{
    public class EntityManager
    {
        static _k_systemsDataSet _K_Systems = new _k_systemsDataSet();

        private static ПользователиTableAdapter пользователиTableAdapter = new ПользователиTableAdapter();
        private static ЗаказыTableAdapter заказыTableAdapter = new ЗаказыTableAdapter();
        private static Цены_работTableAdapter ценыРаботTableAdapter = new Цены_работTableAdapter();
        private static Вид_работTableAdapter вид_РаботTableAdapter = new Вид_работTableAdapter();
        private static Тип_ремонтаTableAdapter тип_РемонтаTableAdapter = new Тип_ремонтаTableAdapter();
        private static Заказы_с_клиентамиTableAdapter заказы_С_КлиентамиTableAdapter = new Заказы_с_клиентамиTableAdapter();
        private static СообщенияTableAdapter сообщенияTableAdapter = new СообщенияTableAdapter();

        static EntityManager()
        {
            // Костыль заменяет оригинальную команду обновления строк во избежание ошибки "Нарушение параллелизма"
            var заказыUpdateCommand = заказыTableAdapter.Adapter.UpdateCommand;
            заказыUpdateCommand.CommandText = "UPDATE `Заказы` SET `Номер клиента` = ?, `Статус заказа` = ?, `Вид работы` = ?," +
                " `Тип работы` = ?, `Цена` = ? WHERE (`Идентификатор` = ?)";
            var parameters = заказыUpdateCommand.Parameters;
            while (parameters.Count > 6)
            {
                заказыTableAdapter.Adapter.UpdateCommand.Parameters.RemoveAt(6);
            }
        }

        public static ПользователиDataTable UserDataTable
        {
            get
            {
                return _K_Systems.Пользователи;
            }
        }

        public static ЗаказыDataTable OrderDataTable
        {
            get
            {
                return _K_Systems.Заказы;
            }
        }

        public static Цены_работDataTable WorkPrices
        {
            get
            {
                return _K_Systems.Цены_работ;
            }
        }

        public static Вид_работDataTable TypeService
        {
            get
            {
                return _K_Systems.Вид_работ;
            }
        }

        public static Тип_ремонтаDataTable TypeRepair
        {
            get
            {
                return _K_Systems.Тип_ремонта;
            }
        }

        public static Заказы_с_клиентамиDataTable OrderClients
        {
            get
            {
                return _K_Systems.Заказы_с_клиентами;
            }
        }

        public static СообщенияDataTable MessageDataTable
        {
            get
            {
                return _K_Systems.Сообщения;
            }
        }

        public static void UpdateUsers()
        {
            пользователиTableAdapter.Adapter.Update(UserDataTable);
        }

        public static void UpdateOrders()
        {
            заказыTableAdapter.Adapter.Update(OrderDataTable);
            OrderDataTable.AcceptChanges();
        }

        public static void UpdateWorkPrices()
        {
            ценыРаботTableAdapter.Adapter.Update(WorkPrices);
        }

        public static void UpdateTypeService()
        {
            вид_РаботTableAdapter.Adapter.Update(TypeService);
        }

        public static void UpdateTypeRepair()
        {
            тип_РемонтаTableAdapter.Adapter.Update(TypeRepair);
        }

        public static void UpdateOrderClients()
        {
            заказы_С_КлиентамиTableAdapter.Adapter.Update(OrderClients);
        }

        internal static void UpdateMessages()
        {
            сообщенияTableAdapter.Adapter.Update(MessageDataTable);
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу пользователей по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static ПользователиDataTable FilterUsers(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = пользователиTableAdapter.Connection,
                CommandText = "SELECT Id, Фамилия, Имя, Отчество, логин, пароль, " +
                $"[E-mail], [Является администратором] FROM Пользователи {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(пользователиTableAdapter.Adapter, filterUserCommand, UserDataTable);

            return UserDataTable;
        }

        /// <summary>
        /// Создает строку для фильтрации: всевозможные комбинации по сравнению предоставленных полей с текстом поиска
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public static string GetFilterStringByFields(string[] fields, string searchText)
        {
            var findValues = string.IsNullOrEmpty(searchText)
                ? new string[] { }
                : searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var filterStrings = new List<string>();
            foreach (var findingField in fields)
            {
                foreach (var findingValue in findValues)
                {
                    filterStrings.Add($"{findingField} LIKE '%{findingValue}%'");
                }
            }

            return string.Join(" OR ", filterStrings);
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу заказов по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static ЗаказыDataTable FilterOrders(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterOrderCommand = new OleDbCommand()
            {
                Connection = заказыTableAdapter.Connection,
                CommandText = "SELECT Идентификатор, [Номер клиента], [Вид работы], [Тип ремонта], Цена, [Статус заказа], Телефон " +
                $"FROM Заказы {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(заказыTableAdapter.Adapter, filterOrderCommand, OrderDataTable);

            return OrderDataTable;
        }

        public static void UpdateOrder(string updateFields, string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var updateOrderCommand = new OleDbCommand()
            {
                Connection = заказыTableAdapter.Connection,
                CommandText = $"UPDATE Заказы SET {updateFields} {whereCondition}",
                CommandType = CommandType.Text
            };
            try
            {
                заказыTableAdapter.Connection.Open();
                updateOrderCommand.ExecuteNonQuery();
            }
            finally
            {
                заказыTableAdapter.Connection.Close();
            }
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу цен работ по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Цены_работDataTable FilterWorkPrices(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = ценыРаботTableAdapter.Connection,
                CommandText = "SELECT Идентификатор, [Вид работы], [Тип ремонта], Цена" +
                $" FROM [Цены работ] {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(ценыРаботTableAdapter.Adapter, filterUserCommand, WorkPrices);

            return WorkPrices;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу вид работы по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Вид_работDataTable FilterTypeService(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = вид_РаботTableAdapter.Connection,
                CommandText = "SELECT Идентификатор, Наименование" +
                $" FROM [Вид работ] {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(вид_РаботTableAdapter.Adapter, filterUserCommand, TypeService);

            return TypeService;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу вид работы по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Тип_ремонтаDataTable FilterTypeRepair(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = тип_РемонтаTableAdapter.Connection,
                CommandText = "SELECT Идентификатор, Наименование" +
                $" FROM [Тип ремонта] {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(тип_РемонтаTableAdapter.Adapter, filterUserCommand, TypeRepair);

            return TypeRepair;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу заказы с клиентами по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static Заказы_с_клиентамиDataTable FilterOrderCkients(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = заказы_С_КлиентамиTableAdapter.Connection,
                CommandText = "SELECT [Номер заказа], [Номер клиента], ФИО, [Вид работы], [Тип ремонта], Цена, [Статус заказа], Телефон" +
                $" FROM [Заказы с клиентами] {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(заказы_С_КлиентамиTableAdapter.Adapter, filterUserCommand, OrderClients);

            return OrderClients;
        }

        /// <summary>
        /// Возвращает отфильтрованную таблицу сообщения по условию <paramref name="condition"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static СообщенияDataTable FilterMessages(string condition = null)
        {
            var whereCondition = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                whereCondition = $"WHERE {condition}";
            }

            var filterUserCommand = new OleDbCommand()
            {
                Connection = сообщенияTableAdapter.Connection,
                CommandText = "SELECT Код, Отправитель, Получатель, Тема, [Текст сообщения]," +
                    " [Прочитано получателем], [Удалено отправителем], [Удалено получателем]" +
                    $" FROM [Сообщения] {whereCondition}",
                CommandType = CommandType.Text
            };

            FillFilteredTable(сообщенияTableAdapter.Adapter, filterUserCommand, MessageDataTable);

            return MessageDataTable;
        }


        /// <summary>
        /// Объединяет условия фильтрации заданным логическим оператором
        /// </summary>
        /// <param name="leftPart"></param>
        /// <param name="rightPart"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        public static string UnionFilter(string leftPart, string rightPart, string @operator = "AND")
        {
            if (string.IsNullOrEmpty(leftPart))
            {
                return rightPart;
            }

            if (string.IsNullOrEmpty(rightPart))
            {
                return leftPart;
            }

            return $"({leftPart}) {@operator} ({rightPart})";
        }

        /// <summary>
        /// Заполняет таблицу по фильтрующей команде выбора строк
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="selectCommand"></param>
        /// <param name="table"></param>
        private static void FillFilteredTable(OleDbDataAdapter adapter, OleDbCommand selectCommand, DataTable table)
        {
            var oldSelectComand = adapter.SelectCommand;
            adapter.SelectCommand = selectCommand;

            table.Clear();

            adapter.Fill(table);
            adapter.SelectCommand = oldSelectComand;
        }
    }
}
