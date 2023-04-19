//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID.Library

 {
    public class Recipe
    {
        private List<Step> steps = new List<Step>();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
    
        public double SumatoriaPrecioUnitario()
        {
            double Costoinsumos = 0.0;  
            foreach (Step step in this.steps)
            {
                Costoinsumos+= step.Input.UnitCost*step.Quantity;
            }
            return Costoinsumos;
        }


            public double SumatoriaUsoCostoporhoraequipo()
            {
                double Costoequipamiento = 0.0;
                foreach(Step step in this.steps)
                {
                    Costoequipamiento+= step.Equipment.HourlyCost*(step.Time/60.0);//divido por 60 para pasar a horas.

                }
                return Costoequipamiento;
            }

                
            public double CalcularPrecioTotal()
            {
                double Costoinsumos=SumatoriaPrecioUnitario();
                double Costoequipamiento=SumatoriaUsoCostoporhoraequipo();
                double SumaTotal=Costoinsumos+Costoequipamiento;
                return SumaTotal;
            }

            public double GetCalcularPrecioTotal()
            {
                return this.CalcularPrecioTotal();
            }
}
// le asigné la responsabilidad de calcular el costo total a la clase recipe siguiendo el patrón expert que dice que una clase debe tener la responsabilidad de una tarea(en este caso calcular el costo total)
// si es experta o posee el conocimiento para llevarla a cabo de manera correcta, lo que sucede en este caso con la clase recipe
// ya que la clase Recipe tiene acceso a los métodos de Step y a la información de Recipe, teniendo esta información
// posee todo el conocimiento para llevar a cabo la tarea de calcular el precio total.
    
 }
