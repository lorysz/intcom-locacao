using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Service.Enums
{
    public enum EnumCadastroLocacao
    {
        [Description("Locação efetuada com sucesso.")]
        Sucesso = 1,
        [Description("Este filme já foi locado por outro cliente.")]
        LocadoOutroCliente = 2,
        [Description("O filme encontra-se locado para este cliente. A data de locação será atualizada. Deseja continuar?")]
        LocadoMesmoCliente = 3
    }
}
