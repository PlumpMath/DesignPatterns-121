﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllIn.StructuralPatterns
{
    /*
     Когда надо осуществлять взаимодействие по сети, а объект-проси должен имитировать поведения объекта
        в другом адресном пространстве. Использование прокси позволяет снизить накладные издержки при передачи данных
            через сеть. Подобная ситуация еще называется удалённый заместитель (remote proxies)

    Когда нужно управлять доступом к ресурсу, создание которого требует больших затрат.
        Реальный объект создается только тогда, когда он действительно может понадобится, а до этого все запросы
            к нему обрабатывает прокси-объект. Подобная ситуация еще называется виртуальный заместитель (virtual proxies)

    Когда необходимо разграничить доступ к вызываемому объекту в зависимости от прав вызывающего объекта. 
        Подобная ситуация еще называется защищающий заместитель (protection proxies)

    Когда нужно вести подсчет ссылок на объект или обеспечить потокобезопасную работу с реальным объектом. 
        Подобная ситуация называется "умные ссылки" (smart reference)
         */
    class Proxy
    {
    }
}
