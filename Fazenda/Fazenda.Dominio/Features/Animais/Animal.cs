using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Animais
{
    public class Animal
    {
        public int Id { get; set; }
        public string Especie { get; set; }

        public void Validar(ICollection<Animal> animais)
        {
            if (string.IsNullOrEmpty(Especie)) throw new AnimalEspecieVaziaExcecao();
            VerificarEspecieRedundante(animais);
        }

        private void VerificarEspecieRedundante(ICollection<Animal> animais)
        {
            foreach (var item in animais)
            {
                if (string.Equals(item.Especie, this.Especie, StringComparison.InvariantCultureIgnoreCase) && item.Id != this.Id) throw new AnimalEspecieRedundanteExcecao();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", Especie);
        }
    }
}
