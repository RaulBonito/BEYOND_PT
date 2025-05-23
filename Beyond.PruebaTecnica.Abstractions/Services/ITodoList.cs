﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.PruebaTecnica.Abstractions.Services;

// El nombre lo dejo tal cual viene en la prueba, pero lo llamaría ITodoListService
public interface ITodoList
{
    void AddItem(int id, string title, string description, string category);
    void UpdateItem(int id, string description);
    void RemoveItem(int id);
    void RegisterProgression(int id, DateTime dateTime, decimal percent);
    void PrintItems();
}
