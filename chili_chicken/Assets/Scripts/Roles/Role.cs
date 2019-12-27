using System.Collections;
using System.Collections.Generic;

public class Role
{
//角色名字和类型
  
public static int a = 3;
public static int get_a()
{
    return a;
}
    private string Name;
    private int Type;
    private bool isMale;
    //学期数
    private int Semester;//0
    //角色属性:专业能力
    private int Computer_c;//1
    private int Mathmatic_c;//2
    private int Electronic_c;//3
    private int Financial_c;//4
    //角色属性：个人素养
    private int Wisdom;//5
    private int EQ;//6
    private int Strength;//7
    private int Hair;//8
    private int Charm;//9
    private float GPA;

    public Role()
    {
        Name = "";
        Type = 0;
        isMale = true;
        Semester = 1;
        Computer_c = 50;
        Mathmatic_c = 50;
        Electronic_c = 50;
        Financial_c = 50;
        Wisdom = 80;
        EQ = 80;
        Strength = 80;
        Hair = 100;
        Charm = 80;
        GPA = 0;
    }
    
    public void setName(string Name)
    {
        this.Name = Name;
    }
    public string getName()
    {
        return this.Name;
    }
    public int getType()
    {
        return this.Type;
    }
    public void setType(int Type)
    {
        this.Type = Type;
    }
    public int getSemester()
    {
        return this.Semester;
    }
    public void addSemester()
    {
        this.Semester += 1;
    }
    public void setCharm(int Charm)
    {
        this.Charm = Charm;
    }
    public int getCharm()
    {
        return this.Charm;
    }
    public void setGender(bool isMale)
    {
        this.isMale = isMale;
    }
    public bool getGender()
    {
        return this.isMale;
    }
    public void addGPA(float bonus_gpa)
    {
        GPA += bonus_gpa;
    }
    public string getGenderString()
    {
        if (this.isMale)
        {
            return "男孩子";
        }
        else
        {
            return "女孩子";
        }
    }
    public void addCharm(int increment)
    {
        this.Charm += increment;
    }

    public void setGPA(float GPA)
    {
        this.GPA = GPA;
    }
    public float getGPA()
    {
        return this.GPA;
    }

    public void setHair(int Hair)
    {
        this.Hair = Hair;
    }
    public int getHair()
    {
        return this.Hair;
    }
    public void addHair(int increment)
    {
        this.Hair += increment;
    }
    public void reduceHair(int decrement)
    {
        this.Hair -= decrement;
    }
    public void setStrength(int Strength)
    {
        this.Strength = Strength;
    }
    public int getStrength()
    {
        return this.Strength;
    }
    public void addStrength(int increment)
    {
        this.Strength += increment;
    }
    public void reduceStrength(int decrement)
    {
        this.Strength -= decrement;
    }
    public void setEQ(int EQ)
    {
        this.EQ = EQ;
    }
    public int getEQ()
    {
        return EQ;
    }
    public void addEQ(int increment)
    {
        this.EQ += increment;
    }
    public void setWisdom(int Wisdom)
    {
        this.Wisdom = Wisdom;
    }
    public int getWisdom()
    {
        return Wisdom;
    }
    public void addWisdom(int increment)
    {
        this.Wisdom += increment;
    }

    public void setComputer_c(int Computer_c)
    {
        this.Computer_c = Computer_c;
    }
    public int getComputer_c()
    {
        return this.Computer_c;
    }
    public void addComputer_c(int increment)
    {
        this.Computer_c += increment;
    }
    public void setMathmatic_c(int Mathmatic_c)
    {
        this.Mathmatic_c = Mathmatic_c;
    }
    public int getMathmatic_c()
    {
        return this.Mathmatic_c;
    }
    public void addMathmatic_c(int increment)
    {
        this.Mathmatic_c += increment;
    }
    public void setElectronic_c(int Electronic_c)
    {
        this.Electronic_c = Electronic_c;
    }
    public int getElectronic_c()
    {
        return this.Electronic_c;
    }
    public void addElectronic_c(int increment)
    {
        this.Electronic_c += increment;
    }
    public void setFinancial_c(int Financial_c)
    {
        this.Financial_c = Financial_c;
    }
    public int getFinancial_c()
    {
        return this.Financial_c;
    }
    public void addFinancial_c(int increment)
    {
        this.Financial_c += increment;
    }

}

