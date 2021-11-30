using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextConta.Models
{
    public class InicializaBD
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            if (context.Nova_Contas.Any())
            {
                return;
            }

            var nova_conta = new Nova_conta[]
            {
                new Nova_conta{Nome= "Iris", Email="iris@gmail.com", Senha="123456"}

            };

            foreach (var item in nova_conta)
            {
                context.Nova_Contas.Add(item);
            }

            context.SaveChanges();

            var novo_grupo = new Novo_Grupo[]
            {
                new Novo_Grupo{Nome= "Netflix"}

            };

            foreach (var item in novo_grupo)
            {
                context.Novo_Grupos.Add(item);
            }

            context.SaveChanges();
        }


    }
}

