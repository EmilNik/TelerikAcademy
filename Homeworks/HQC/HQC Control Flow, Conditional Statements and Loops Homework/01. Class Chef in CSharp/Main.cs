using _01.Class_Chef_in_CSharp;
//Refactor the following class using best practices for organizing straight-line code:

public class Chef
{
    public void Cook()
    {
        Bowl bowl = this.GetBowl();
        Potato potato = this.GetPotato();
        Carrot carrot = this.GetCarrot();

        this.Peel(potato);
        this.Peel(carrot);

        this.Cut(potato);
        this.Cut(carrot);

        bowl.Add(carrot);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        //... 
    }

    private Carrot GetCarrot()
    {
        //...
    }

    private Potato GetPotato()
    {
        //...
    }

    private void Peel(Vegetable vegetable)
    {
        throw new System.NotImplementedException();
    }

    private void Cut(Vegetable vegetable)
    {
        throw new System.NotImplementedException();
    }
}