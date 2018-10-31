using Fazenda.Dominio.Features.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazenda.Apresentacao.Features.Animais
{
    public class GerenciadorFormularioAnimal : IFormulario
    {
        private Animal _animal;
        private ControleAnimal _controleAnimal;
        private CadastroAnimalForm _dialogo;
        IAnimalServico _animalServico;
        ICollection<Animal> _animais;

        public GerenciadorFormularioAnimal(IAnimalServico animalServico)
        {
            _dialogo = new CadastroAnimalForm();
            _animalServico = animalServico;
        }

        public void Adicionar()
        {

            try
            {
                DialogResult resultado = _dialogo.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _animal = _dialogo.novoAnimal;
                    _animalServico.Adicionar(_animal);
                    MessageBox.Show("Animal registrado com sucesso!");
                }
                _dialogo.LimparCampos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Adicionar();
            }
        }

        public void AtualizarLista()
        {
            try
            {
                _animais = _animalServico.PegarTodos().OrderBy(p => p.Especie).ToList();
                _controleAnimal.CarregarLista(_animais);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AtualizarListaReloadBancoDados()
        {
            try
            {
                _animais = _animalServico.PegarTodosReloadBancoDados().OrderBy(p => p.Especie).ToList();
                _controleAnimal.CarregarLista(_animais);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void AtualizarLista(string[] termoParaPesquisar)
        {
            try
            {
                _animais = _animalServico.PegarTodos().ToList();
                if (!string.IsNullOrEmpty(termoParaPesquisar[4]))
                    _animais = _animais.Where(a => a.Especie.ToUpper().Contains(termoParaPesquisar[4].ToUpper())).ToList();
                _animais = _animais.OrderBy(a => a.Especie).ToList();
                _controleAnimal.CarregarLista(_animais);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public UserControl CarregarListagem()
        {
            if (_controleAnimal == null)
                _controleAnimal = new ControleAnimal();

            return _controleAnimal;
        }

        public void Editar()
        {
            if (_controleAnimal.ObterAnimalSelecionado() == null)
                MessageBox.Show("Precisa selecionar um animal.");

            else
            {
                try
                {
                    _dialogo.novoAnimal = _controleAnimal.ObterAnimalSelecionado();

                    DialogResult resultado = _dialogo.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        _animal = new Animal();
                        _animal = _dialogo.novoAnimal;
                        _animalServico.Atualizar(_animal);
                        MessageBox.Show("Animal atualizado com sucesso!");
                    }
                    _dialogo.LimparCampos();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro");
                    Editar();
                }
            }
        }

        public void Excluir()
        {
            if (_controleAnimal.ObterAnimalSelecionado() == null)
                MessageBox.Show("Precisa selecionar um animal.");
            else
            {
                try
                {
                    _animal = _controleAnimal.ObterAnimalSelecionado();
                    DialogResult resultado = MessageBox.Show("Confirmar exclusão do animal: \n" + _animal.ToString(), "Excluir Animal", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        _animalServico.Remover(_animal);
                        MessageBox.Show("Animal deletado com sucesso!");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro");
                }
            }
        }

        public string ObtemTipoCadastro()
        {
            return "ANIMAIS";
        }
    }
}
