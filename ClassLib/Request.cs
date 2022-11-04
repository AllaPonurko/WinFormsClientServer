using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Enum;

namespace Lib
{
    /// <summary>
    /// Протокол построения запроса к серверу
    /// </summary>
    [Serializable]
    public class Request
    {
        /// <summary>
        /// Команда, которую должен выполнить сервер
        /// </summary>
        public RequestCommands Command;

        /// <summary>
        /// Данные для работы сервера
        /// </summary>
        public object Body;
        

        // url, method, body

    }
}
