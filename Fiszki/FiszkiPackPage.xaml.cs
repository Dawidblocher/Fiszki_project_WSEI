﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fiszki
{
    /// <summary>
    /// Logika interakcji dla klasy FiszkiPackPage.xaml
    /// </summary>
    public partial class FiszkiPackPage : Page
    {
        Game newGame;
        ListBoxItem DataContext { get; set; }
        Fiche activeFiche { get; set; }
        public FiszkiPackPage()
        {
            InitializeComponent();
        }

        public FiszkiPackPage(ListBoxItem data) : this()
        {
            DataContext = data;
            LabelCategory.Content = $"Kategoria: {DataContext.Content.ToString()}";
            newGame = new Game(DataContext.Content.ToString());
            generateFiche();
            initRound();
        }

        public void generateFiche()
        {
            if(newGame.fichePack.Count > 0)
            {
                Random rnd = new Random();
                int poczatek = 0;
                int koniec = newGame.fichePack.Count;
                int wylosowana = rnd.Next(poczatek, koniec); 
                activeFiche = newGame.fichePack[wylosowana];
                initRound();
            }
            else
            {
                FicheText.Text = "Lekcja skończona";
                LabelPoints.Content = $"Zdobyte punkty: {newGame.points}";
                LabelFaul.Content = $"Pomyłki: {newGame.faul}";
                AswerBox.Text = "";
                activeFiche = null;
            }
        }

        public void initRound()
        {
            FicheText.Text = activeFiche.English;
            LabelPoints.Content = $"Zdobyte punkty: {newGame.points}";
            LabelFaul.Content = $"Pomyłki: {newGame.faul}";
            AswerBox.Text = "";
        }

        public void updateFichePack()
        {
            newGame.fichePack.Remove(activeFiche);
        }

        private void Check_Aswer_Button_Click(object sender, RoutedEventArgs e)
        {
            if (newGame.fichePack.Count > 0)
            {
                string answer = AswerBox.Text;
                answer = answer.ToLower();
                if (answer == activeFiche.Polish)
                {
                    newGame.points += 1;
                    updateFichePack();
                    generateFiche();
                }
                else
                {
                    newGame.faul += 1;                    
                    initRound();

                }
            }   
        }
        private void Next_Fiche_Button_Click(object sender, RoutedEventArgs e)
        {
            if (newGame.fichePack.Count > 0)
            {
                DatabaseAccess.InsertFicheToRepeats(activeFiche.Id, activeFiche.English, activeFiche.Polish, activeFiche.CategoryId);
                newGame.faul += 1;
                updateFichePack();
                generateFiche();
            }
        }

        private void AswerBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
