using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Генератор уникальных Id для сущностей приложения.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Значение следующего Id, которое будет выдано.
        /// </summary>
        private static int _id = 1;

        /// <summary>
        /// Возвращает очередной уникальный Id и увеличивает счётчик.
        /// </summary>
        public static int GetNextId()
        {
            return _id++;
        }
    }
}
