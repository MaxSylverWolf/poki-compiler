using Pokemon_Compilator.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Compilator.Compilers
{
    public class Compiler
    {
        public string Line { get; set; }
        public Form1 formObject;

        public Compiler(Form1 form)
        {
            formObject = form;
        }

        public Compiler() { }

        public List<Numeric> listNumeric = new List<Numeric>();
        public List<Strings> listStrings = new List<Strings>();
        public List<Functions> listFunctions = new List<Functions>();

        public bool isExistinNumeric(List<Numeric> numericList, string valueName)
        {
            bool check = false;

            foreach (Numeric n in numericList)
            {
                if (n.Name.Equals(valueName)) check = true;
            }

            return check;
        }

        public bool isExistInFunctions(List<Functions> functionsList, string valueName)
        {
            bool check = false;

            foreach (Functions n in functionsList)
            {
                if (n.Name.Equals(valueName)) check = true;
            }

            return check;
        }

        public bool isExistinStrings(List<Strings> stringList, string valueName)
        {
            bool check = false;
            foreach (Strings n in stringList)
            {
                if (n.Name.Equals(valueName)) check = true;
            }
            return check;
        }

        public Double getValueFromNumericList(List<Numeric> numericList, string valueName)
        {
            Double check = 0;
            foreach (Numeric n in numericList)
            {
                if (n.Name.Equals(valueName))
                {
                    check = n.Value;
                }
            }
            return check;
        }

        public List<string> getInstructionsFromFunctionsList(List<Functions> functionsList, string valueName)
        {
            List<string> instructions = new List<string>();
            foreach (Functions n in functionsList)
            {
                if (n.Name.Equals(valueName))
                {
                    foreach (string s in n.Instructions) instructions.Add(s);
                }
            }
            return instructions;
        }

        public Numeric getFromNumericList(List<Numeric> numericList, string valueName)
        {
            Numeric check = new Numeric();
            foreach (Numeric n in numericList)
            {
                if (n.Name.Equals(valueName))
                {
                    check = new Numeric(n.Name, n.Value, n.Attack, n.Health, n.TypePocket);
                }
            }
            return check;
        }

        public Strings getFromStringsList(List<Strings> stringsList, string valueName)
        {
            Strings check = new Strings();
            foreach (Strings n in stringsList)
            {
                if (n.Name.Equals(valueName))
                {
                    check = new Strings(n.Name, n.Value, n.Attack, n.Health, n.TypePocket);
                }
            }
            return check;
        }

        public string getValueFromStringsList(List<Strings> stringsList, string valueName)
        {
            string check = "";
            foreach (Strings n in stringsList)
            {
                if (n.Name.Equals(valueName))
                {
                    check = n.Value;
                }
            }
            return check;
        }

        public bool setFromStringsList(List<Strings> stringsList, string valueName, string type, string value)
        {
            bool ifSet = false;
            foreach (Strings n in stringsList)
            {
                if (n.Name.Equals(valueName))
                {
                    if (type.Equals("value")) { ifSet = true; n.Value = value; break; }
                    if (type.Equals("attack")) { if (IsNumeric(value)) { ifSet = true; n.Attack = Double.Parse(value); break; } }
                    if (type.Equals("health")) { if (IsNumeric(value)) { ifSet = true; n.Health = Double.Parse(value); break; } }
                    if (type.Equals("type")) { ifSet = true; n.TypePocket = value; break; }
                }
            }
            return ifSet;
        }

        public bool setFromNumericList(List<Numeric> numericList, string valueName, string type, string value)
        {
            bool ifSet = false;
            foreach (Numeric n in numericList)
            {
                if (n.Name.Equals(valueName))
                {
                    if (type.Equals("value")) { if (IsNumeric(value)) { ifSet = true; n.Value = Double.Parse(value); break; } }
                    if (type.Equals("attack")) { if (IsNumeric(value)) { ifSet = true; n.Attack = Double.Parse(value); break; } }
                    if (type.Equals("health")) { if (IsNumeric(value)) { ifSet = true; n.Health = Double.Parse(value); break; } }
                    if (type.Equals("type")) { ifSet = true; n.TypePocket = value; break; }

                }
            }
            return ifSet;
        }

        public string incFromNumericList(List<Numeric> numericList, string valueName, string type, string value)
        {
            string ifSet = "";
            foreach (Numeric n in numericList)
            {
                if (n.Name.Equals(valueName))
                {
                    if (type.Equals("value")) { if (IsNumeric(value)) { n.Value = n.Value+Double.Parse(value); ifSet = n.Value.ToString(); break; } }
                    if (type.Equals("attack")) { if (IsNumeric(value)) { n.Attack = n.Attack+Double.Parse(value); ifSet = n.Attack.ToString(); break; } }
                    if (type.Equals("health")) { if (IsNumeric(value)) { n.Health = n.Health+Double.Parse(value); ifSet = n.Health.ToString(); break; } }                  
                }
            }
            return ifSet;
        }

        public string incFromStringsList(List<Strings> stringsList, string valueName, string type, string value)
        {
            string ifSet = "";
            foreach (Strings n in stringsList)
            {
                if (n.Name.Equals(valueName))
                {
                    if (type.Equals("attack")) { if (IsNumeric(value)) {  n.Attack = n.Attack+Double.Parse(value); ifSet = n.Attack.ToString(); break; } }
                    if (type.Equals("health")) { if (IsNumeric(value)) {  n.Health = n.Health+Double.Parse(value); ifSet = n.Health.ToString(); break; } }
                }
            }
            return ifSet;
        }

        public void deleteElemFromNumericList(List<Numeric> numericList, string valueName)
        {
            foreach (Numeric n in numericList)
            {
                if (n.Name.Equals(valueName))
                {
                    numericList.Remove(n);
                    break;
                }
            }
        }

        public void deleteElemFromStringsList(List<Strings> stringsList, string valueName)
        {
            foreach (Strings n in stringsList)
            {
                if (n.Name.Equals(valueName))
                {
                    stringsList.Remove(n);
                    break;
                }
            }
        }

        public string compile(string line)
        {
            string myOutput = "";
            string[] liner = (line.Trim()).Split();
            if (liner[0].Equals("swift"))
            {
                if (liner.Length == 4) myOutput = swiftCalculation(liner);
                if (liner.Length == 5) myOutput = swiftInitializeVariableFromCalc(liner);
                if (liner.Length <= 3 || liner.Length > 5) myOutput = "Error$ parsing swift method. Please check your code.";
            }
            if (liner[0].Equals("pocket"))
            {
                if (liner[1].Equals("print")) myOutput = pocketPrint(liner);
            }
            if (liner[0].Equals("pokeball"))
            {
                myOutput = pokeballInitializeVariable(liner);
            }
            if (liner[0].Equals("pokedex"))
            {
                myOutput = pokedexChecker(liner);
            }
            if (liner[0].Equals("evolution"))
            {
                myOutput = evolutionInitializeFun(liner, line);
            }
            if (liner[0].Equals("battle"))
            {
                if (liner[1].Equals("go"))
                {
                    List<string> outputBattleGo = battleGo(liner);
                    foreach (string o in outputBattleGo) myOutput += o + "\n";
                }
                if (!liner[1].Equals("go")) myOutput = "Error$. Method not found";
            }
            if (liner[0].Equals("go"))
            {
                if (liner[1].Equals("attack"))
                {
                    List<string> outputAttack = goAttack(liner, line);
                    foreach (string o in outputAttack) myOutput += o + "\n";
                }
                if (liner[1].Equals("when"))
                {
                    List<string> outputWhen = goWhen(liner, line);
                    foreach (string o in outputWhen) myOutput += o + "\n";
                }
            }
            if (liner[0].Equals("island"))
            {

            }
            else if (!liner[0].Equals("swift") && !liner[0].Equals("pocket") && !liner[0].Equals("pokeball")
                && !liner[0].Equals("pokedex") && !liner[0].Equals("evolution") && !liner[0].Equals("battle")
                && !liner[0].Equals("go") && !liner[0].Equals("island") && !liner[0].Equals("$") && !liner[0].Equals("#") && !liner[0].Equals(""))
            {
                myOutput = "Error$. Method not found.";
            }
            return myOutput;
        }
        public static bool IsNumeric(object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public double add(double one, double two)
        {
            return one + two;
        }
        public string addString(string one, string two)
        {
            one += two;
            return one;
        }
        public double minus(double one, double two)
        {
            return one - two;
        }
        public double mul(double one, double two)
        {
            return one * two;
        }
        public double div(double one, double two)
        {
            return one / two;
        }
        public string pocketPrint(string[] toInterpret)
        {
            string line = "";
            for (int i = 2; i < toInterpret.Length; i++)
            {
                string[] checkHash = toInterpret[i].Split('#');
                if (isExistinNumeric(listNumeric, checkHash[0].ToString()))
                {
                    if (i + 1 < toInterpret.Length)
                    {
                        string[] checkHash2 = toInterpret[i + 1].Split('#');
                        if (checkHash2[0].Equals("getAll")) line += getFromNumericList(listNumeric, checkHash[0].ToString()).ToString() + " ";
                        if (checkHash2[0].Equals("getName")) line += getFromNumericList(listNumeric, checkHash[0].ToString()).Name + " ";
                        if (checkHash2[0].Equals("getValue")) line += getFromNumericList(listNumeric, checkHash[0].ToString()).Value + " ";
                        if (checkHash2[0].Equals("getAttack")) line += getFromNumericList(listNumeric, checkHash[0].ToString()).Attack + " ";
                        if (checkHash2[0].Equals("getHealth")) line += getFromNumericList(listNumeric, checkHash[0].ToString()).Health + " ";
                        if (checkHash2[0].Equals("getType")) line += getFromNumericList(listNumeric, checkHash[0].ToString()).TypePocket + " ";
                    }
                    else if (i + 1 >= toInterpret.Length)
                    {
                        line += getFromNumericList(listNumeric, checkHash[0].ToString()).Name + " ";
                    }
                }
                if (isExistinStrings(listStrings, checkHash[0].ToString()))
                {
                    if (i + 1 < toInterpret.Length)
                    {
                        string[] checkHash2 = toInterpret[i + 1].Split('#');
                        if (checkHash2[0].Equals("getAll")) line += getFromStringsList(listStrings, checkHash[0].ToString()).ToString() + " ";
                        if (checkHash2[0].Equals("getName")) line += getFromStringsList(listStrings, checkHash[0].ToString()).Name + " ";
                        if (checkHash2[0].Equals("getValue")) line += getFromStringsList(listStrings, checkHash[0].ToString()).Value + " ";
                        if (checkHash2[0].Equals("getAttack")) line += getFromStringsList(listStrings, checkHash[0].ToString()).Attack + " ";
                        if (checkHash2[0].Equals("getHealth")) line += getFromStringsList(listStrings, checkHash[0].ToString()).Health + " ";
                        if (checkHash2[0].Equals("getType")) line += getFromStringsList(listStrings, checkHash[0].ToString()).TypePocket + " ";
                    }
                    else if (i + 1 >= toInterpret.Length)
                    {
                        line += getFromStringsList(listStrings, checkHash[0].ToString()).Name + " ";
                    }
                }
                else if (!isExistinStrings(listStrings, checkHash[0].ToString()) && !isExistinNumeric(listNumeric, checkHash[0].ToString()))
                    if (!checkHash[0].Equals("getAll") && !checkHash[0].Equals("getName") && !checkHash[0].Equals("getValue") &&
                        !checkHash[0].Equals("getAttack") && !checkHash[0].Equals("getHealth") && !checkHash[0].Equals("getType"))
                        line += checkHash[0].ToString() + " ";
            }
            return line;
        }

        public string evolutionInitializeFun(string[] toInterpret, string lineFull)
        {
            string line = "";

            string[] evolution = (lineFull.Trim()).Split('#');
            string[] toGo = (toInterpret[1].Trim()).Split('#');
            if (!IsNumeric(toGo[0]))
            {
                bool isExistInFuns = isExistInFunctions(listFunctions, toGo[0].ToString());
                if (!isExistInFuns)
                {
                    List<string> ins = new List<string>();
                    for (int i = 1; i < evolution.Length; i++) ins.Add(evolution[i].ToString().Trim());
                    Functions n = new Functions(toGo[0].ToString(), ins);
                    listFunctions.Add(n);
                    line = "One evolution added. Name: " + toGo[0].ToString();
                }
                else if (isExistInFuns) line = "Error$. Function exist!";
            }
            else if (IsNumeric(toGo[0]))
            {
                line = "Error$. Functions name can't be a number. Evolution method failed.";
            }
            return line;
        }

        public List<string> battleGo(string[] toInterpret)
        {
            List<string> line = new List<string>();

            if (!IsNumeric(toInterpret[2]))
            {
                bool isExistInFuns = isExistInFunctions(listFunctions, toInterpret[2].ToString());
                if (isExistInFuns)
                {
                    List<string> ins = getInstructionsFromFunctionsList(listFunctions, toInterpret[2].ToString());
                    foreach (string s in ins) line.Add(compile(s));
                }
                else if (!isExistInFuns) line.Add("Error$. Function is not exist!");
            }
            else if (IsNumeric(toInterpret[2]))
            {
                line.Add("Error$. Functions name can't be a number. Battle go method failed.");
            }
            return line;
        }

        public string pokedexChecker(string[] toInterpret)
        {
            string line = "";
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("all"))
            {
                line = "Pokedex list\n";
                foreach (Strings s in listStrings) line += s.ToString() + "\n";
                foreach (Numeric n in listNumeric) line += n.ToString() + "\n";
            }
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("input") && toInterpret[2].Equals("show"))
            {
                line = "Input show$";
                formObject.showInput();
            }
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("input") && toInterpret[2].Equals("hide"))
            {
                line = "Input hide";
                formObject.closeInput();
            }
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("input") && toInterpret[2].Equals("save"))
            {
                string input = formObject.getValueInput();
                if (!input.Trim().Equals(""))
                {
                    if (!isExistinNumeric(listNumeric, toInterpret[3]) && !isExistinStrings(listStrings, toInterpret[3]))
                    {
                        if (IsNumeric(input)) listNumeric.Add(new Numeric(toInterpret[3], Double.Parse(input)));
                        if (!IsNumeric(input)) listStrings.Add(new Strings(toInterpret[3], input));
                        line = "Input saved as " + toInterpret[3] + " = " + input;
                    }
                    else if (isExistinNumeric(listNumeric, toInterpret[3]) || isExistinStrings(listStrings, toInterpret[3]))
                        line = "Error$. Variable was initialized earlier";
                }
                else if(input.Trim().Equals(""))
                {
                    line = "Error$. Empty input";
                }
            }
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("release") && toInterpret[2].Equals("all"))
            {
                listNumeric.Clear();
                listNumeric = new List<Numeric>();
                listStrings.Clear();
                listStrings = new List<Strings>();
                line = "Pokedex, variables released all";
            }
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("release") && isExistinNumeric(listNumeric, toInterpret[2].ToString()))
            {
                deleteElemFromNumericList(listNumeric, getFromNumericList(listNumeric, toInterpret[2].ToString()).Name);
                line = "Pokedex, variable = " + toInterpret[2].ToString() + " released";
            }
            if (!IsNumeric(toInterpret[1]) && toInterpret[1].Equals("release") && isExistinStrings(listStrings, toInterpret[2].ToString()))
            {
                deleteElemFromStringsList(listStrings, getFromStringsList(listStrings, toInterpret[2].ToString()).Name);
                line = "Pokedex, variable = " + toInterpret[2].ToString() + " released";
            }
            if (!IsNumeric(toInterpret[1]) && !toInterpret[1].Equals("all") && !toInterpret[1].Equals("release") && !toInterpret[1].Equals("input"))
            {
                bool isExistNum = isExistinNumeric(listNumeric, toInterpret[1].ToString());
                bool isExistStr = isExistinStrings(listStrings, toInterpret[1].ToString());
                if (isExistNum)
                {
                    if (toInterpret[2].Equals("all"))
                    {
                        line = "Pokedex variable show:\n";
                        line += getFromNumericList(listNumeric, toInterpret[1].ToString()).ToString();

                    }
                    if (toInterpret[2].Equals("get"))
                    {
                        if (toInterpret[3].Equals("name")) line = getFromNumericList(listNumeric, toInterpret[1].ToString()).Name;
                        if (toInterpret[3].Equals("value")) line = getFromNumericList(listNumeric, toInterpret[1].ToString()).Value.ToString();
                        if (toInterpret[3].Equals("attack")) line = getFromNumericList(listNumeric, toInterpret[1].ToString()).Attack.ToString();
                        if (toInterpret[3].Equals("health")) line = getFromNumericList(listNumeric, toInterpret[1].ToString()).Health.ToString();
                        if (toInterpret[3].Equals("type")) line = getFromNumericList(listNumeric, toInterpret[1].ToString()).TypePocket;
                        else if (!toInterpret[3].Equals("name") && !toInterpret[3].Equals("value") &&
                            !toInterpret[3].Equals("attack") && !toInterpret[3].Equals("health") &&
                            !toInterpret[3].Equals("type")) line = "Error$. Method not found";
                    }
                    if (toInterpret[2].Equals("set"))
                    {
                        if (toInterpret[3].Equals("name")) line = "Error$. You can't change name of variable";
                        if (toInterpret[3].Equals("value")) line = "Var set = " + setFromNumericList(listNumeric, toInterpret[1].ToString(), "value", toInterpret[4]);
                        if (toInterpret[3].Equals("attack")) line = "Var set = " + setFromNumericList(listNumeric, toInterpret[1].ToString(), "attack", toInterpret[4]);
                        if (toInterpret[3].Equals("health")) line = "Var set = " + setFromNumericList(listNumeric, toInterpret[1].ToString(), "health", toInterpret[4]);
                        if (toInterpret[3].Equals("type"))
                        {
                            string myObject = "";
                            for (int i = 4; i < toInterpret.Length; i++) myObject += toInterpret[i].ToString() + " ";
                            line = "Var set = " + setFromStringsList(listStrings, toInterpret[1].ToString(), "type", myObject);
                        }
                        else if (!toInterpret[3].Equals("name") && !toInterpret[3].Equals("value") &&
                            !toInterpret[3].Equals("attack") && !toInterpret[3].Equals("health") &&
                            !toInterpret[3].Equals("type")) line = "Error$. Method not found";
                    }
                    if (toInterpret[2].Equals("inc"))
                    {
                        if (toInterpret[3].Equals("name")) line = "Error$. You can't inc name of variable";
                        if (toInterpret[3].Equals("value")) line = "Var inc = " + incFromNumericList(listNumeric, toInterpret[1].ToString(), "value", toInterpret[4]);
                        if (toInterpret[3].Equals("attack")) line = "Var inc = " + incFromNumericList(listNumeric, toInterpret[1].ToString(), "attack", toInterpret[4]);
                        if (toInterpret[3].Equals("health")) line = "Var inc = " + incFromNumericList(listNumeric, toInterpret[1].ToString(), "health", toInterpret[4]);
                        if (toInterpret[3].Equals("type")) line = "Error$. You can't inc type of variable";
                        else if (!toInterpret[3].Equals("name") && !toInterpret[3].Equals("value") &&
                            !toInterpret[3].Equals("attack") && !toInterpret[3].Equals("health") &&
                            !toInterpret[3].Equals("type")) line = "Error$. Method not found";
                    }
                    else if (!toInterpret[2].Equals("get") && !toInterpret[2].Equals("set") && !toInterpret[3].Equals("all") && !toInterpret[3].Equals("inc")) line = "Error$. Method not found.";
                }
                if (isExistStr)
                {
                    if (toInterpret[2].Equals("get"))
                    {
                        if (toInterpret[3].Equals("name")) line = getFromStringsList(listStrings, toInterpret[1].ToString()).Name;
                        if (toInterpret[3].Equals("value")) line = getFromStringsList(listStrings, toInterpret[1].ToString()).Value.ToString();
                        if (toInterpret[3].Equals("attack")) line = getFromStringsList(listStrings, toInterpret[1].ToString()).Attack.ToString();
                        if (toInterpret[3].Equals("health")) line = getFromStringsList(listStrings, toInterpret[1].ToString()).Health.ToString();
                        if (toInterpret[3].Equals("type")) line = getFromStringsList(listStrings, toInterpret[1].ToString()).TypePocket;
                        else if (!toInterpret[3].Equals("name") && !toInterpret[3].Equals("value") &&
                            !toInterpret[3].Equals("attack") && !toInterpret[3].Equals("health") &&
                            !toInterpret[3].Equals("type")) line = "Error$. Method not found";
                    }
                    if (toInterpret[2].Equals("set"))
                    {
                        if (toInterpret[3].Equals("name")) line = "Error$. You can't change name of variable";
                        if (toInterpret[3].Equals("value"))
                        {
                            string myObject = "";
                            for (int i = 4; i < toInterpret.Length; i++) myObject += toInterpret[i].ToString() + " ";
                            line = "Var set = " + setFromStringsList(listStrings, toInterpret[1].ToString(), "value", myObject);
                        }
                        if (toInterpret[3].Equals("attack")) line = "Var set = " + setFromStringsList(listStrings, toInterpret[1].ToString(), "attack", toInterpret[4]);
                        if (toInterpret[3].Equals("health")) line = "Var set = " + setFromStringsList(listStrings, toInterpret[1].ToString(), "health", toInterpret[4]);
                        if (toInterpret[3].Equals("type"))
                        {
                            string myObject = "";
                            for (int i = 4; i < toInterpret.Length; i++) myObject += toInterpret[i].ToString() + " ";
                            line = "Var set = " + setFromStringsList(listStrings, toInterpret[1].ToString(), "type", myObject);
                        }
                        else if (!toInterpret[3].Equals("name") && !toInterpret[3].Equals("value") &&
                            !toInterpret[3].Equals("attack") && !toInterpret[3].Equals("health") &&
                            !toInterpret[3].Equals("type")) line = "Error$. Method not found";
                    }
                    if (toInterpret[2].Equals("inc"))
                    {
                        if (toInterpret[3].Equals("name")) line = "Error$. You can't inc name of variable";
                        if (toInterpret[3].Equals("value")) line = "Error$. You can't inc value of variable";
                        if (toInterpret[3].Equals("attack")) line = "Var inc = " + incFromStringsList(listStrings, toInterpret[1].ToString(), "attack", toInterpret[4]);
                        if (toInterpret[3].Equals("health")) line = "Var inc = " + incFromStringsList(listStrings, toInterpret[1].ToString(), "health", toInterpret[4]);
                        if (toInterpret[3].Equals("type")) line = "Error$. You can't inc type of variable";
                        else if (!toInterpret[3].Equals("name") && !toInterpret[3].Equals("value") &&
                            !toInterpret[3].Equals("attack") && !toInterpret[3].Equals("health") &&
                            !toInterpret[3].Equals("type")) line = "Error$. Method not found";
                    }
                    if (toInterpret[2].Equals("all"))
                    {
                        line = "Pokedex variable show:\n";
                        line += getFromStringsList(listStrings, toInterpret[1].ToString()).ToString();

                    }
                    else if (!toInterpret[2].Equals("get") && !toInterpret[2].Equals("set") && !toInterpret[3].Equals("all") && !toInterpret[3].Equals("inc")) line = "Error$. Method not found.";
                }
                else if (!isExistNum && !isExistStr) line = "Error$. Variable wasn't initialized earlier.";
            }
            else if (IsNumeric(toInterpret[1])) line = "Error$. Number is not a valid name.";

            return line;
        }

        public string pokeballInitializeVariable(string[] toInterpret)
        {
            string line = "";
            if (!bigNopeForMethodsName(toInterpret[1]))
            {
                if (!IsNumeric(toInterpret[1]))
                {
                    if (IsNumeric(toInterpret[2]))
                    {
                        bool isExistNum = isExistinNumeric(listNumeric, toInterpret[1].ToString());
                        bool isExistStr = isExistinStrings(listStrings, toInterpret[1].ToString());
                        if (!isExistNum && !isExistStr)
                        {
                            listNumeric.Add(new Numeric(toInterpret[1], Double.Parse(toInterpret[2])));
                            line = "Added " + toInterpret[1] + " = " + toInterpret[2];

                        }
                        else if (isExistNum || isExistStr) line = "Error$. Variable was initialized earlier.";
                    }
                    else
                    {
                        bool isExistNum = isExistinNumeric(listNumeric, toInterpret[1].ToString());
                        bool isExistStr = isExistinStrings(listStrings, toInterpret[1].ToString());
                        if (!isExistStr && !isExistNum)
                        {
                            bool isExistNum2 = isExistinNumeric(listNumeric, toInterpret[2].ToString());
                            bool isExistStr2 = isExistinStrings(listStrings, toInterpret[2].ToString());
                            if (!isExistNum2 && !isExistStr2)
                            {
                                string myObject = "";
                                for (int i = 2; i < toInterpret.Length; i++) myObject += toInterpret[i].ToString() + " ";
                                listStrings.Add(new Strings(toInterpret[1], myObject.Trim()));
                                line = "Added strings " + toInterpret[1] + " = " + myObject;
                            }
                            if (isExistNum2 && !isExistStr2)
                            {
                                double myObject = 0;
                                myObject = getValueFromNumericList(listNumeric, toInterpret[2]);
                                listNumeric.Add(new Numeric(toInterpret[1], myObject));
                                line = "Added numeric " + toInterpret[1] + " = " + myObject;
                            }
                            if (!isExistNum2 && isExistStr2)
                            {
                                string myObject = "";
                                myObject = getValueFromStringsList(listStrings, toInterpret[2]);
                                listStrings.Add(new Strings(toInterpret[1], myObject.Trim()));
                                line = "Added strings " + toInterpret[1] + " = " + myObject;
                            }

                        }
                        else if (isExistStr || isExistNum) line = "Error$. Variable was initialized earlier.";
                    }
                }
                else if (IsNumeric(toInterpret[1])) line = "Error$. Variable name can't be a number";
            }
            else if (bigNopeForMethodsName(toInterpret[1]))
            {
                line = "Error$. You're an idiot!!!";
            }
            return line;
        }

        public List<string> goWhen(string[] toInterpret, string lineFull)
        {
            List<string> line = new List<string>();
            string[] when = (lineFull.Trim()).Split('#');
            string[] lastHashLost = toInterpret[4].Trim().Split('#');
            bool isExistNum1 = isExistinNumeric(listNumeric, toInterpret[2]);
            bool isExistNum2 = isExistinNumeric(listNumeric, lastHashLost[0]);
            bool isExistStr1 = isExistinStrings(listStrings, toInterpret[2]);
            bool isExistStr2 = isExistinStrings(listStrings, lastHashLost[0]);

            if (isExistNum1 && isExistNum2)
            {
                if (toInterpret[3] == ">")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) > getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) < getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "=")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) == getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) != getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<=" || toInterpret[3] == "=<")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) <= getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == ">=" || toInterpret[3] == "=>")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) >= getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=" && toInterpret[3] != ">"
                && toInterpret[3] != "<" && toInterpret[3] != "<=" && toInterpret[3] != "=<"
                 && toInterpret[3] != ">=" && toInterpret[3] != "=>") line.Add("Error$. I can't go when through this. :(");
            }
            if (!isExistNum1 && isExistNum2 && IsNumeric(toInterpret[2]))
            {
                if (toInterpret[3] == ">")
                {
                    if (Double.Parse(toInterpret[2]) > getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<")
                {
                    if (Double.Parse(toInterpret[2]) < getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "=")
                {
                    if (Double.Parse(toInterpret[2]) == getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (Double.Parse(toInterpret[2]) != getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<=" || toInterpret[3] == "=<")
                {
                    if (Double.Parse(toInterpret[2]) <= getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == ">=" || toInterpret[3] == "=>")
                {
                    if (Double.Parse(toInterpret[2]) >= getValueFromNumericList(listNumeric, lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=" && toInterpret[3] != ">"
                && toInterpret[3] != "<" && toInterpret[3] != "<=" && toInterpret[3] != "=<"
                 && toInterpret[3] != ">=" && toInterpret[3] != "=>") line.Add("Error$. I can't go when through this. :(");
            }
            if (isExistNum1 && !isExistNum2)
            {
                if (toInterpret[3] == ">")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) > Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) < Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "=")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) == Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) != Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<=" || toInterpret[3] == "=<")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) <= Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == ">=" || toInterpret[3] == "=>")
                {
                    if (getValueFromNumericList(listNumeric, toInterpret[2]) >= Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=" && toInterpret[3] != ">"
                && toInterpret[3] != "<" && toInterpret[3] != "<=" && toInterpret[3] != "=<"
                 && toInterpret[3] != ">=" && toInterpret[3] != "=>") line.Add("Error$. I can't go when through this. :(");
            }
            if (isExistStr1 && isExistStr2)
            {
                if (toInterpret[3] == "=")
                {
                    if (getValueFromStringsList(listStrings, toInterpret[2]).Equals(getValueFromStringsList(listStrings, lastHashLost[0])))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (!getValueFromStringsList(listStrings, toInterpret[2]).Equals(getValueFromStringsList(listStrings, lastHashLost[0])))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=") line.Add("Error$. I can't go when through this. :(");
            }
            if (!isExistStr1 && isExistStr2 && !IsNumeric(toInterpret[2]))
            {
                if (toInterpret[3] == "=")
                {
                    if (toInterpret[2].Equals(getValueFromStringsList(listStrings, lastHashLost[0])))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (toInterpret[2].Equals(getValueFromStringsList(listStrings, lastHashLost[0])))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=") line.Add("Error$. I can't go when through this. :(");
            }
            if (isExistStr1 && !isExistStr2 && !IsNumeric(lastHashLost[0]))
            {
                if (toInterpret[3] == "=")
                {
                    if (getValueFromStringsList(listStrings, toInterpret[2]).Equals(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (!getValueFromStringsList(listStrings, toInterpret[2]).Equals(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=") line.Add("Error$. I can't go when through this. :(");
            }
            if (!isExistNum1 && !isExistNum2 && IsNumeric(toInterpret[2]) && IsNumeric(lastHashLost[0]))
            {
                if (toInterpret[3] == ">")
                {
                    if (Double.Parse(toInterpret[2]) > Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<")
                {
                    if (Double.Parse(toInterpret[2]) < Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "=")
                {
                    if (Double.Parse(toInterpret[2]) == Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (Double.Parse(toInterpret[2]) != Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "<=" || toInterpret[3] == "=<")
                {
                    if (Double.Parse(toInterpret[2]) <= Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == ">=" || toInterpret[3] == "=>")
                {
                    if (Double.Parse(toInterpret[2]) >= Double.Parse(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=" && toInterpret[3] != ">"
                    && toInterpret[3] != "<" && toInterpret[3] != "<=" && toInterpret[3] != "=<"
                    && toInterpret[3] != ">=" && toInterpret[3] != "=>") line.Add("Error$. I can't go when through this. :(");
            }
            if (!isExistNum1 && !isExistNum2 && !isExistStr1 && !isExistStr2 && !IsNumeric(toInterpret[2]) && !IsNumeric(lastHashLost[0]))
            {
                if (toInterpret[3] == "=")
                {
                    if (toInterpret[2].Equals(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] == "!=")
                {
                    if (!toInterpret[2].Equals(lastHashLost[0]))
                    {
                        for (int i = 1; i < when.Length; i++) line.Add(compile(when[i]));
                    }
                }
                if (toInterpret[3] != "=" && toInterpret[3] != "!=") line.Add("Error$. I can't go when through this. :(");
            }
            if ((!IsNumeric(toInterpret[2]) && IsNumeric(lastHashLost[0]) && !isExistNum1) ||
                (IsNumeric(toInterpret[2]) && !IsNumeric(lastHashLost[0]) && !isExistNum2)) line.Add("Error$. You're an idiot!");

            return line;
        }

        public List<string> goAttack(string[] toInterpret, string lineFull)
        {
            List<string> line = new List<string>();
            line.Add("Output Attack:");
            string[] attack = (lineFull.Trim()).Split('#');
            string[] toGo = (toInterpret[2].Trim()).Split('#');
            if (IsNumeric(toGo[0]))
            {
                int go = (int)Math.Floor(Double.Parse(toGo[0]));
                for (int j = 1; j < go + 1; j++)
                {
                    for (int i = 1; i < attack.Length; i++) line.Add(compile(attack[i]));
                }
            }
            else if (!IsNumeric(toGo[0]))
            {
                bool isExistNum = isExistinNumeric(listNumeric, toGo[0]);
                bool isExistStr = isExistinStrings(listStrings, toGo[0]);
                if (isExistNum)
                {
                    int go = (int)Math.Floor(getValueFromNumericList(listNumeric, toGo[0]));
                    for (int j = 1; j < go; j++)
                    {
                        for (int i = 1; i < attack.Length; i++) line.Add(compile(attack[i]));
                    }
                }
                else if (!isExistNum) line.Add("Error$. Variable wasn't initialized earlier. Go Attack method failed.");
                else if (isExistStr) line.Add("Error$. Variable is Strings. You can't loop it through this.");
                else if (!isExistStr) line.Add("Error$. Variable wasn't initialized earlier. Go Attack method failed.");
            }
            return line;
        }

        public string swiftInitializeVariableFromCalc(string[] toInterpret)
        {
            string line = "";
            if (!bigNopeForMethodsName(toInterpret[1]))
            {
                if (!IsNumeric(toInterpret[1]))
                {
                    if (IsNumeric(toInterpret[2]) && IsNumeric(toInterpret[4]))
                    {
                        double result = 0;
                        bool isExistNum = isExistinNumeric(listNumeric, toInterpret[1].ToString());
                        bool isExistStr = isExistinStrings(listStrings, toInterpret[1].ToString());
                        if (!isExistNum && !isExistStr)
                        {
                            if (toInterpret[3] == "+")
                            {
                                result = add(Double.Parse(toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Added " + toInterpret[1] + " = " + result;

                            }
                            if (toInterpret[3] == "-")
                            {
                                result = minus(Double.Parse(toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Minus " + toInterpret[1] + " = " + result;
                            }
                            if (toInterpret[3] == "*")
                            {
                                result = mul(Double.Parse(toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Mul " + toInterpret[1] + " = " + result;
                            }
                            if (toInterpret[3] == "/")
                            {
                                result = div(Double.Parse(toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Div " + toInterpret[1] + " = " + result;
                            }
                            else if (toInterpret[3] != "+" && toInterpret[3] != "-" && toInterpret[3] != "*" && toInterpret[3] != "/")
                            {
                                line = "Error$. I can't initialize this :(";
                            }
                        }
                        else if (isExistNum || isExistStr) line = "Error$. Variable was initialized earlier.";

                    }
                    else
                    {
                        if (isExistinNumeric(listNumeric, toInterpret[2]) && !isExistinNumeric(listNumeric, toInterpret[4])
                    && IsNumeric(toInterpret[4]) && !isExistinStrings(listStrings, toInterpret[4]))
                        {
                            double result = 0;
                            if (toInterpret[3] == "+")
                            {
                                result = add(getValueFromNumericList(listNumeric, toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Add result = " + result;
                            }
                            if (toInterpret[3] == "-")
                            {
                                result = minus(getValueFromNumericList(listNumeric, toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Minus result = " + result;
                            }
                            if (toInterpret[3] == "*")
                            {
                                result = mul(getValueFromNumericList(listNumeric, toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Mul result = " + result;
                            }
                            if (toInterpret[3] == "/")
                            {
                                result = div(getValueFromNumericList(listNumeric, toInterpret[2]), Double.Parse(toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Div result = " + result;
                            }
                            else if (toInterpret[3] != "+" && toInterpret[3] != "-" && toInterpret[3] != "*" && toInterpret[3] != "/")
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (!isExistinNumeric(listNumeric, toInterpret[2]) && isExistinNumeric(listNumeric, toInterpret[4])
                            && IsNumeric(toInterpret[2]) && !isExistinStrings(listStrings, toInterpret[2]))
                        {
                            double result = 0;
                            if (toInterpret[3] == "+")
                            {
                                result = add(Double.Parse(toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Add result = " + result;

                            }
                            if (toInterpret[3] == "-")
                            {
                                result = minus(Double.Parse(toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Minus result = " + result;
                            }
                            if (toInterpret[3] == "*")
                            {
                                result = mul(Double.Parse(toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Mul result = " + result;
                            }
                            if (toInterpret[3] == "/")
                            {
                                result = div(Double.Parse(toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Div result = " + result;
                            }
                            else if (toInterpret[3] != "+" && toInterpret[3] != "-" && toInterpret[3] != "*" && toInterpret[3] != "/")
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (isExistinNumeric(listNumeric, toInterpret[2]) && isExistinNumeric(listNumeric, toInterpret[4]))
                        {
                            double result = 0;
                            if (toInterpret[3] == "+")
                            {
                                result = add(getValueFromNumericList(listNumeric, toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Add result = " + result;
                            }
                            if (toInterpret[3] == "-")
                            {
                                result = minus(getValueFromNumericList(listNumeric, toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Minus result = " + result;
                            }
                            if (toInterpret[3] == "*")
                            {
                                result = mul(getValueFromNumericList(listNumeric, toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Mul result = " + result;
                            }
                            if (toInterpret[3] == "/")
                            {
                                result = div(getValueFromNumericList(listNumeric, toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]));
                                listNumeric.Add(new Numeric(toInterpret[1], result));
                                line = "Div result = " + result;
                            }
                            else if (toInterpret[3] != "+" && toInterpret[3] != "-" && toInterpret[2] != "*" && toInterpret[3] != "/")
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (isExistinStrings(listStrings, toInterpret[2]) && !isExistinStrings(listStrings, toInterpret[4])
                            && !isExistinNumeric(listNumeric, toInterpret[4]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(getValueFromStringsList(listStrings, toInterpret[2]), toInterpret[4]);
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (!isExistinStrings(listStrings, toInterpret[2]) && isExistinStrings(listStrings, toInterpret[4])
                            && !isExistinNumeric(listNumeric, toInterpret[2]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(toInterpret[2], getValueFromStringsList(listStrings, toInterpret[4]));
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (!isExistinStrings(listStrings, toInterpret[2]) && isExistinStrings(listStrings, toInterpret[4])
                        && isExistinNumeric(listNumeric, toInterpret[2]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(getValueFromNumericList(listNumeric, toInterpret[2]).ToString(), getValueFromStringsList(listStrings, toInterpret[4]));
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (isExistinStrings(listStrings, toInterpret[2]) && !isExistinStrings(listStrings, toInterpret[4])
                        && isExistinNumeric(listNumeric, toInterpret[4]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(getValueFromStringsList(listStrings, toInterpret[2]), getValueFromNumericList(listNumeric, toInterpret[4]).ToString());
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (isExistinStrings(listStrings, toInterpret[2]) && isExistinStrings(listStrings, toInterpret[4]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(getValueFromStringsList(listStrings, toInterpret[2]), getValueFromStringsList(listStrings, toInterpret[4]));
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (!isExistinStrings(listStrings, toInterpret[2]) && !isExistinStrings(listStrings, toInterpret[4])
                            && !isExistinNumeric(listNumeric, toInterpret[2]) && !isExistinNumeric(listNumeric, toInterpret[4]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(toInterpret[2], toInterpret[4]);
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (!isExistinStrings(listStrings, toInterpret[2]) && !isExistinStrings(listStrings, toInterpret[4])
                        && !isExistinNumeric(listNumeric, toInterpret[2]) && isExistinNumeric(listNumeric, toInterpret[4]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(toInterpret[2], getValueFromNumericList(listNumeric, toInterpret[4]).ToString());
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                        if (!isExistinStrings(listStrings, toInterpret[2]) && !isExistinStrings(listStrings, toInterpret[4])
                        && isExistinNumeric(listNumeric, toInterpret[2]) && !isExistinNumeric(listNumeric, toInterpret[4]))
                        {
                            if (toInterpret[3] == "+")
                            {

                                string result = addString(getValueFromNumericList(listNumeric, toInterpret[2]).ToString(), toInterpret[4]);
                                listStrings.Add(new Strings(toInterpret[1], result));
                                line = "Add strings result = " + result;
                            }
                            else
                            {
                                line = "Error$. I can't calculate this :(";
                            }
                        }
                    }
                }
                else if (IsNumeric(toInterpret[1])) line = "Error$. Variable name can't be a number";
            }
            else if (bigNopeForMethodsName(toInterpret[1]))
            {
                line = "Error$. You're an idiot!!!";
            }
            return line;
        }

        public string swiftCalculation(string[] toInterpret)
        {
            string line = "";

            if (IsNumeric(toInterpret[1]) && IsNumeric(toInterpret[3]))
            {
                double result = 0;
                if (toInterpret[2] == "+")
                {
                    result = add(Double.Parse(toInterpret[1]), Double.Parse(toInterpret[3]));
                    line = "Add result = " + result;

                }
                if (toInterpret[2] == "-")
                {
                    result = minus(Double.Parse(toInterpret[1]), Double.Parse(toInterpret[3]));
                    line = "Minus result = " + result;
                }
                if (toInterpret[2] == "*")
                {
                    result = mul(Double.Parse(toInterpret[1]), Double.Parse(toInterpret[3]));
                    line = "Mul result = " + result;
                }
                if (toInterpret[2] == "/")
                {
                    result = div(Double.Parse(toInterpret[1]), Double.Parse(toInterpret[3]));
                    line = "Div result = " + result;
                }
                else if (toInterpret[2] != "+" && toInterpret[2] != "-" && toInterpret[2] != "*" && toInterpret[2] != "/")
                {
                    line = "Error$. I can't calculate this :(";
                }
            }
            else
            {
                if (isExistinNumeric(listNumeric, toInterpret[1]) && !isExistinNumeric(listNumeric, toInterpret[3])
                    && IsNumeric(toInterpret[3]) && !isExistinStrings(listStrings, toInterpret[3]))
                {
                    double result = 0;
                    if (toInterpret[2] == "+")
                    {
                        result = add(getValueFromNumericList(listNumeric, toInterpret[1]), Double.Parse(toInterpret[3]));
                        line = "Add result = " + result;

                    }
                    if (toInterpret[2] == "-")
                    {
                        result = minus(getValueFromNumericList(listNumeric, toInterpret[1]), Double.Parse(toInterpret[3]));
                        line = "Minus result = " + result;
                    }
                    if (toInterpret[2] == "*")
                    {
                        result = mul(getValueFromNumericList(listNumeric, toInterpret[1]), Double.Parse(toInterpret[3]));
                        line = "Mul result = " + result;
                    }
                    if (toInterpret[2] == "/")
                    {
                        result = div(getValueFromNumericList(listNumeric, toInterpret[1]), Double.Parse(toInterpret[3]));
                        line = "Div result = " + result;
                    }
                    else if (toInterpret[2] != "+" && toInterpret[2] != "-" && toInterpret[2] != "*" && toInterpret[2] != "/")
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (!isExistinNumeric(listNumeric, toInterpret[1]) && isExistinNumeric(listNumeric, toInterpret[3])
                    && IsNumeric(toInterpret[1]) && !isExistinStrings(listStrings, toInterpret[1]))
                {
                    double result = 0;
                    if (toInterpret[2] == "+")
                    {
                        result = add(Double.Parse(toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Add result = " + result;

                    }
                    if (toInterpret[2] == "-")
                    {
                        result = minus(Double.Parse(toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Minus result = " + result;
                    }
                    if (toInterpret[2] == "*")
                    {
                        result = mul(Double.Parse(toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Mul result = " + result;
                    }
                    if (toInterpret[2] == "/")
                    {
                        result = div(Double.Parse(toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Div result = " + result;
                    }
                    else if (toInterpret[2] != "+" && toInterpret[2] != "-" && toInterpret[2] != "*" && toInterpret[2] != "/")
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (isExistinNumeric(listNumeric, toInterpret[1]) && isExistinNumeric(listNumeric, toInterpret[3]))
                {
                    double result = 0;
                    if (toInterpret[2] == "+")
                    {
                        result = add(getValueFromNumericList(listNumeric, toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Add result = " + result;

                    }
                    if (toInterpret[2] == "-")
                    {
                        result = minus(getValueFromNumericList(listNumeric, toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Minus result = " + result;
                    }
                    if (toInterpret[2] == "*")
                    {
                        result = mul(getValueFromNumericList(listNumeric, toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Mul result = " + result;
                    }
                    if (toInterpret[2] == "/")
                    {
                        result = div(getValueFromNumericList(listNumeric, toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]));
                        line = "Div result = " + result;
                    }
                    else if (toInterpret[2] != "+" && toInterpret[2] != "-" && toInterpret[2] != "*" && toInterpret[2] != "/")
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (isExistinStrings(listStrings, toInterpret[1]) && !isExistinStrings(listStrings, toInterpret[3])
                    && !isExistinNumeric(listNumeric, toInterpret[3]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(getValueFromStringsList(listStrings, toInterpret[1]), toInterpret[3]);
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (!isExistinStrings(listStrings, toInterpret[1]) && isExistinStrings(listStrings, toInterpret[3])
                    && !isExistinNumeric(listNumeric, toInterpret[1]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(toInterpret[1], getValueFromStringsList(listStrings, toInterpret[3]));
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (!isExistinStrings(listStrings, toInterpret[1]) && isExistinStrings(listStrings, toInterpret[3])
                && isExistinNumeric(listNumeric, toInterpret[1]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(getValueFromNumericList(listNumeric, toInterpret[1]).ToString(), getValueFromStringsList(listStrings, toInterpret[3]));
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (isExistinStrings(listStrings, toInterpret[1]) && !isExistinStrings(listStrings, toInterpret[3])
                && isExistinNumeric(listNumeric, toInterpret[3]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(getValueFromStringsList(listStrings, toInterpret[1]), getValueFromNumericList(listNumeric, toInterpret[3]).ToString());
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (isExistinStrings(listStrings, toInterpret[1]) && isExistinStrings(listStrings, toInterpret[3]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(getValueFromStringsList(listStrings, toInterpret[1]), getValueFromStringsList(listStrings, toInterpret[3]));
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (!isExistinStrings(listStrings, toInterpret[1]) && !isExistinStrings(listStrings, toInterpret[3])
                    && !isExistinNumeric(listNumeric, toInterpret[1]) && !isExistinNumeric(listNumeric, toInterpret[3]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(toInterpret[1], toInterpret[3]);
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (!isExistinStrings(listStrings, toInterpret[1]) && !isExistinStrings(listStrings, toInterpret[3])
                    && !isExistinNumeric(listNumeric, toInterpret[1]) && isExistinNumeric(listNumeric, toInterpret[3]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(toInterpret[1], getValueFromNumericList(listNumeric,toInterpret[3]).ToString());
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }
                if (!isExistinStrings(listStrings, toInterpret[1]) && !isExistinStrings(listStrings, toInterpret[3])
                && isExistinNumeric(listNumeric, toInterpret[1]) && !isExistinNumeric(listNumeric, toInterpret[3]))
                {
                    if (toInterpret[2] == "+")
                    {

                        string result = addString(getValueFromNumericList(listNumeric,toInterpret[1]).ToString(), toInterpret[3]);
                        line = "Add strings result = " + result;
                    }
                    else
                    {
                        line = "Error$. I can't calculate this :(";
                    }
                }

            }
            return line;
        }

        public bool bigNopeForMethodsName(string check)
        {
            bool lol = false;

            if (check.Equals("swift") || check.Equals("pokeball") || check.Equals("print") || check.Equals("pocket") || check.Equals("pokedex") ||
                check.Equals("evolution") || check.Equals("battle") || check.Equals("go") || check.Equals("attack") ||
                check.Equals("when") || check.Equals("island") || check.Equals("+") || check.Equals("-") ||
                check.Equals("/") || check.Equals("*") || check.Equals("=") || check.Equals("!=") ||
                check.Equals("<") || check.Equals("<=") || check.Equals("=<") ||
                check.Equals(">") || check.Equals(">=") || check.Equals("=>")
                || check.Equals("all") || check.Equals("getName") || check.Equals("getValue") || check.Equals("getAttack")
                || check.Equals("getHealth") || check.Equals("getType") || check.Equals("set") || check.Equals("get")
                || check.Equals("setName") || check.Equals("setValue") || check.Equals("setAttack")
                || check.Equals("setHealth") || check.Equals("setType") || check.Equals("health")
                || check.Equals("name") || check.Equals("value") || check.Equals("typePocket") || check.Equals("type")
                || check.Equals("inc") || check.Equals("input") && check.Equals("show") && check.Equals("hide") &&
                check.Equals("save")) lol = true;

            return lol;
        }
    }
}
