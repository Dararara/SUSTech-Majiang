using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private class CouresRecords
    {
        public int[] result = new int[10];
        public float GPA = 2.95f;
        private int allCourses = 0;
        private int num_course1 = 0;
        private int num_course2 = 0;
        private int num_course3 = 0;
        private int num_course4 = 0;
        private int num_course5 = 0;
        private int num_tuple1 = 0;
        private int num_tuple2 = 0;
        private int num_tuple3 = 0;
        private int num_tuple4 = 0;
        private int num_tuple5 = 0;

        public string generateResults()
        {
            string rst = "";
            if (getTuplesNum() >= 5)
            {
                if (num_tuple1 > 4)
                {
                    rst += ComputerStarting;
                }
                else if (num_tuple2 > 4)
                {
                    rst += FinaStarting;
                }
                else if (num_tuple3 > 4)
                {
                    rst += MathStarting;
                }
                else if (num_tuple4 > 4)
                {
                    rst += ElecStarting;
                }
                else if (num_tuple5 > 4)
                {
                    rst += OptionStarting;
                }
                else
                {
                    rst += Starting3;
                }
            }
            else if (getTuplesNum() == 4)
            {
                rst += Starting4;
            }
            else if (getTuplesNum() == 3)
            {
                rst += Starting1;
            }
            else if (getTuplesNum() == 2)
            {
                rst += Starting5;
            }
            else if (getTuplesNum() == 1)
            {
                rst += Starting2;
            }
            else
            {
                rst += BadStarting;
            }

            rst += getString();

            if (result[8] < 0)
            {
                string temp = role.getGender() ? "女朋友的。" : "男朋友的。";
                rst += "在你获得好成绩的同时，请关照下你的头发。若不然，你会找不到" + temp;
            }
            else
            {
                rst += "虽然你这学期成绩不太好，但是万幸的是：你没有脱发。";
            }

            if (result[7] == 0)
            {
                result[7] -= 5;
                rst += "还有，身体才是革命的本钱，没有身体怎么肝期末的那么多project?劝君多锻炼。";
            }
            else
            {
                rst += "还有，学习与运动结合，才是最配的大学生活。";
            }
            return rst;
        }
        private string getString()
        {
            string result = "经过一学期的努力（划水），你完成本学期（第" + (role.getSemester() - 1) + "学期)的课程，是时候看下你的学习报告了。本学期，你共选课" + allCourses + "门。其中，";
            if (this.num_course1 != 0)
            {
                result += "" + num_course1 + "门" + departments[1] + "的课;";
            }
            if (this.num_course2 != 0)
            {
                result += "" + num_course2 + "门" + departments[2] + "的课;";
            }
            if (this.num_course3 != 0)
            {
                result += "" + num_course3 + "门" + departments[3] + "的课;";
            }
            if (this.num_course4 != 0)
            {
                result += "" + num_course4 + "门" + departments[4] + "的课;";
            }
            if (this.num_course5 != 0)
            {
                result += "" + num_course5 + "门" + departments[5] + "的课;";
            }
            result += "不仅如此啊，你还" +
               "完成了’融汇贯通‘和'专心致志'共计" + getTuplesNum() + "个。";
            return result;
        }
        public void calculateGPA(int cnt)
        {
            this.GPA -= 0.1f * (cnt - 3 * (this.num_tuple1 + this.num_tuple2 + this.num_tuple3 + this.num_tuple4 + this.num_tuple5));
        }
        private int getAllCount(List<int> handTiles, List<int> showTiles)
        {
            int cnt = 0;
            int lastTile = -1;
            foreach (int tile in handTiles)
            {
                if (tile != -1)
                {
                    if (lastTile != tile)
                    {
                        lastTile = tile;
                        cnt++;
                    }
                }
            }
            foreach (int tile in showTiles)
            {
                if (tile != -1)
                {
                    if (lastTile != tile)
                    {
                        lastTile = tile;
                        cnt++;
                    }
                }
            }
            return cnt;
        }
        private int getTuplesNum()
        {
            return this.num_tuple1 + this.num_tuple2 + this.num_tuple3 + this.num_tuple4 + this.num_tuple5;
        }
        public void calculateScorebyList(List<int> tuples, bool win)
        {
            int bonus = win ? 2 : 1;
            int baseScore = 2;
            foreach (int tuple in tuples)
            {
                this.GPA += 0.2f;
                if (tuple % 10 == 0)
                {
                    baseScore = 2;
                    List<int> addIndex = getAddAttributes(tuple);
                    foreach (int index in addIndex)
                    {
                        result[index] += win ? baseScore * bonus : baseScore;
                    }
                    num_tuple5++;
                }
                else
                {
                    baseScore = 3;
                    if (getDepartementNum(tuple) < 2)
                    {
                        if (getDepartementNum(tuple) % 2 == 1)
                            result[1] += win ? (baseScore + 1) * bonus : (baseScore + 1);
                        else
                            result[1] += win ? baseScore * bonus : baseScore;
                        num_tuple1++;
                    }
                    else if (getDepartementNum(tuple) < 4)
                    {
                        if (getDepartementNum(tuple) % 2 == 1)
                            result[4] += win ? (baseScore + 1) * bonus : (baseScore + 1);
                        else
                            result[4] += win ? baseScore * bonus : baseScore;
                        num_tuple2++;
                    }
                    else if (getDepartementNum(tuple) < 6)
                    {
                        if (getDepartementNum(tuple) % 2 == 1)
                            result[2] += win ? (baseScore + 1) * bonus : (baseScore + 1);
                        else
                            result[2] += win ? baseScore * bonus : baseScore;
                        num_tuple3++;
                    }
                    else if (getDepartementNum(tuple) < 8)
                    {
                        if (getDepartementNum(tuple) % 2 == 1)
                            result[3] += win ? (baseScore + 1) * bonus : (baseScore + 1);
                        else
                            result[3] += win ? baseScore * bonus : baseScore;
                        num_tuple4++;
                    }
                }
            }
        }
        public int[] calculateScore(List<int> handTiles, List<int> showTiles, bool win)
        {
            List<int> allTiles = new List<int>();
            foreach (int tuple in handTiles)
            {
                if (tuple == 10 || tuple == 20 || tuple == 30 || tuple == 40 || tuple == 50)
                {
                    result[7] += 2;
                }
                allTiles.Add(tuple);
            }
            foreach (int tuple in showTiles)
            {
                if (tuple == 10 || tuple == 20 || tuple == 30 || tuple == 40 || tuple == 50)
                {
                    result[7] += 2;
                }
                allTiles.Add(tuple);
            }
            calculateCourseNum(allTiles);
            allCourses = getAllCount(handTiles, showTiles);
            List<int> total_tuples = getTuples(handTiles);
            List<int> tuples = getTuples(showTiles);
            foreach (int tuple in tuples)
            {
                total_tuples.Add(tuple);
            }
            calculateScorebyList(total_tuples, win);
            if (win)
            {
                this.result[8] -= 5;
                this.result[5] += 5;
            }
            else
            {
                if (getTuplesNum() == 0)
                {
                    this.result[8] += 2;
                    this.result[5] -= 2;
                }
                else if (getTuplesNum() == 1)
                {
                    this.result[8] += 1;
                }
                else if (getTuplesNum() == 2)
                {
                    this.result[8] -= 1;
                    this.result[5] += 2;
                }
                else if (getTuplesNum() == 3)
                {
                    this.result[8] -= 2;
                    this.result[5] += 2;
                }
                else
                {
                    this.result[8] -= 4;
                    this.result[5] += 4;
                }
            }
            return this.result;
        }
        public void calculateCourseNum(List<int> Tiles)
        {
            List<int> temp = new List<int>();
            int lastTile = -1;
            foreach (int tile in Tiles)
            {
                if (lastTile != tile)
                {
                    lastTile = tile;
                    temp.Add(tile);
                }
            }
            foreach (int id in temp)
            {
                if (getDepartementNum(id) < 2)
                {
                    this.num_course1++;
                }
                else if (getDepartementNum(id) < 4)
                {
                    this.num_course2++;
                }
                else if (getDepartementNum(id) < 6)
                {
                    this.num_course3++;
                }
                else if (getDepartementNum(id) < 8)
                {
                    this.num_course4++;
                }
                else
                {
                    if (id != -1)
                    {
                        this.num_course5++;
                    }

                }
            }
        }

    }
    private static Role role = new Lolita();
    private static List<float> GPA_list = new List<float>();
    private static string[] departments = { "", "计算机系", "金融系", "数学系", "电子系", "选修" };
    private static CouresRecords thisSemester = null;

    private static string Starting1 = "那是最美好的学期，那是最糟糕的学期；那是智慧的年头，那是愚昧的年头；我们都直奔高GPA，仿佛那才是终点。";
    private static string Starting2 = "凡是GPA低的学生，总想着玩，但你不得不承认，他们真的很快乐。";
    private static string Starting3 = "我的字典里，有两个词，一个是大佬，另一个还是大佬。";
    private static string Starting4 = "追寻高GPA根本就是场悲剧，所以我们就不拿它当悲剧了。";
    private static string Starting5 = "对于大部分人来说，普通和平凡才是一生。";
    private static string ComputerStarting = "我们要让中国消费者知道，hp不是'high price'，而是'high performance'。你似乎在为了实现这句话而努力。";
    private static string ElecStarting = "只有一条路不能选择--那就是放弃的路；只有一条路不能拒绝--那就是成长的路。你走在成长的路上。";
    private static string FinaStarting = "重要的不是你的判断是错是对，而是你正确的时候要最大限度的发挥出你的力量来。金融尤其如此。";
    private static string MathStarting = "数学支配着宇宙。你似乎想要探索宇宙的奥妙。";
    private static string OptionStarting = "有的人就是不走寻常路，你就是其中之一。在你眼里，只有选修课。";
    private static string BadStarting = "对于学困生，说来我们的做法也很简单，首先是要有爱心和恒心。";
    //选修课
    enum optionalCourse
    {
        足球, 篮球, 排球, 网球, 游泳, 西方音乐史, 空间中的美术史, 工笔花鸟, 科幻电影鉴赏,
        想象力入门, 人文讲座, 教你唱歌, 心理学, 人格塑造, 诗词格律, 美术鉴赏, 中文信息处理, 经典导读, 休闲文化, 理解死亡
    };
    //专业课
    enum Course { Cs2, Cs3, Fin2, Fin3, Mth2, Mth3, Elc2, Elc3, Others };

    public static Role createRole(string Name, bool Gender, int Type)
    {
        role = RoleFactory.getRolebyType(Type);
        role.setName(Name);
        role.setGender(Gender);
        role.setType(Type);
        return role;
    }
    public static Role getRole()
    {
        return role;
    }
    public static List<int> getAddAttributes(int id) //对应课程加对应属性
    {
        List<int> AttributesIndex = new List<int>();
        if (id % 10 != 0)
        {
            if (id >= 21 && id <= 29 && id >= 31 && id <= 39)
            {
                AttributesIndex.Add(1);
            }
            else if (id >= 41 && id <= 49 && id >= 51 && id <= 59)
            {
                AttributesIndex.Add(4);
            }
            else if (id >= 61 && id <= 69 && id >= 71 && id <= 79)
            {
                AttributesIndex.Add(2);
            }
            else if (id >= 81 && id <= 89 && id >= 91 && id <= 99)
            {
                AttributesIndex.Add(3);
            }
            return AttributesIndex;
        }
        switch (id)
        {
            case 10 * (int)optionalCourse.足球:
                AttributesIndex.Add(7);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.篮球:
                AttributesIndex.Add(7);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.排球:
                AttributesIndex.Add(7);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.网球:
                AttributesIndex.Add(7);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.游泳:
                AttributesIndex.Add(7);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.西方音乐史:
                AttributesIndex.Add(6);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.空间中的美术史:
                AttributesIndex.Add(6);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.工笔花鸟:
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.科幻电影鉴赏:
                AttributesIndex.Add(5);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.想象力入门:
                AttributesIndex.Add(5);
                AttributesIndex.Add(6);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.人文讲座:
                AttributesIndex.Add(5);
                AttributesIndex.Add(6);
                break;
            case 10 * (int)optionalCourse.教你唱歌:
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.心理学:
                AttributesIndex.Add(5);
                AttributesIndex.Add(6);
                break;
            case 10 * (int)optionalCourse.人格塑造:
                AttributesIndex.Add(5);
                break;
            case 10 * (int)optionalCourse.诗词格律:
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.美术鉴赏:
                AttributesIndex.Add(6);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.中文信息处理:
                AttributesIndex.Add(1);
                AttributesIndex.Add(5);
                break;
            case 10 * (int)optionalCourse.经典导读:
                AttributesIndex.Add(6);
                AttributesIndex.Add(9);
                break;
            case 10 * (int)optionalCourse.休闲文化:
                AttributesIndex.Add(6);
                break;
            case 10 * (int)optionalCourse.理解死亡:
                AttributesIndex.Add(5);
                break;
            default:
                break;
        }
        return AttributesIndex;
    }
    public static int getDepartementNum(int target)//给出牌id，确定来自某个系或者是选修课
    {
        if (target >= 21 && target <= 29)
        {
            return (int)Course.Cs2;
        }
        else if (target >= 31 && target <= 39)
        {
            return (int)Course.Cs3;
        }
        else if (target >= 41 && target <= 49)
        {
            return (int)Course.Fin2;
        }
        else if (target >= 51 && target <= 59)
        {
            return (int)Course.Fin3;
        }
        else if (target >= 61 && target <= 69)
        {
            return (int)Course.Mth2;
        }
        else if (target >= 71 && target <= 79)
        {
            return (int)Course.Mth3;
        }
        else if (target >= 81 && target <= 89)
        {
            return (int)Course.Elc2;
        }
        else if (target >= 91 && target <= 99)
        {
            return (int)Course.Elc3;
        }
        else
        {
            return (int)Course.Others;
        }
    }
    private static List<int> getTuples(List<int> Tiles)
    {
        int max_num_tuple = 0;
        List<int> max_tuple = new List<int>();
        while (Tiles.Count >= 3)
        {
            List<int> temp_Tiles = Copy(Tiles);
            int cnt = 0;
            List<int> temp_tuple = new List<int>();
        a:
            {
                while (temp_Tiles.Count >= 3)
                {
                    for (int i = 0; i < temp_Tiles.Count - 2; i++)
                    {
                        for (int j = i + 1; j < temp_Tiles.Count - 1; j++)
                        {
                            for (int k = j + 1; k < temp_Tiles.Count; k++)
                            {
                                if ((temp_Tiles[i] == temp_Tiles[j] && temp_Tiles[j] == temp_Tiles[k]) || (temp_Tiles[i] == temp_Tiles[j] - 1 && temp_Tiles[j] == temp_Tiles[k] - 1))
                                {
                                    temp_tuple.Add(temp_Tiles[i]);
                                    List<int> temp = new List<int>();
                                    for (int t = 0; t < temp_Tiles.Count; t++)
                                    {
                                        if (t == i || t == j || t == k)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            temp.Add(temp_Tiles[t]);
                                        }
                                    }
                                    temp_Tiles = Copy(temp);
                                    cnt++;
                                    goto a;
                                }
                            }
                        }
                    }
                    if (temp_Tiles.Count > 0)
                    {
                        temp_Tiles.RemoveAt(0);
                    }


                }
            }
            if (cnt > max_num_tuple)
            {
                max_num_tuple = cnt;
                max_tuple = temp_tuple;
            }
            if (Tiles.Count > 0)
            {
                Tiles.RemoveAt(0);
            }
        }
        return max_tuple;

    }
    public static int getTuplesNum(List<int> handTiles)
    {
        List<int> h_Tiles = new List<int>();
        List<int> h_Tiles_w = new List<int>();
        foreach (int id in handTiles)
        {

            if (id % 10 == 0)
            {
                h_Tiles_w.Add(id);
            }
            else
            {
                h_Tiles.Add(id);
            }
        }
        return getTuples(h_Tiles).Count + getTuples(h_Tiles_w).Count;

    }
    public static float getGPA()
    {
        float averag_GPA = 0.0f;

        for (int i = 0; i < GPA_list.Count; i++)
        {
            averag_GPA += GPA_list[i];
        }
        averag_GPA = averag_GPA / GPA_list.Count;
        return averag_GPA;
    }
    private static void updateRole()
    {
        role.addSemester();
        role.setGPA(getGPA());
        role.addComputer_c(thisSemester.result[1]);
        role.addMathmatic_c(thisSemester.result[2]);
        role.addElectronic_c(thisSemester.result[3]);
        role.addFinancial_c(thisSemester.result[4]);
        role.addWisdom(thisSemester.result[5]);
        role.addEQ(thisSemester.result[6]);
        role.addStrength(thisSemester.result[7]);
        role.addHair(thisSemester.result[8]);
        role.addCharm(thisSemester.result[9]);
    }

    public static int[] getScores(List<int> handTiles, List<int> showTiles, bool win)
    {
        
        int cnt = handTiles.Count + showTiles.Count;
        thisSemester = new CouresRecords();
        int[] temp = thisSemester.calculateScore(handTiles, showTiles, win);
        thisSemester.calculateGPA(cnt);     
        GPA_list.Add(thisSemester.GPA);     
        updateRole();
        handTiles.Sort();
        showTiles.Sort();
        foreach (int i in handTiles)
        {
            Debug.Log(i);
        }
        foreach (int i in showTiles)
        {
            Debug.Log(i);
        }
        return temp;
    }
    public static string GetEndName()
    {
        string rst = "普通结局";
        if (role.getGPA() > 3.8)
        {
            rst = "超神结局";
        }
        else if (role.getComputer_c() > 100)
        {
            rst = "计算机结局";
        }
        else if (role.getElectronic_c() > 100)
        {
            rst = "电子系结局";
        }
        else if (role.getFinancial_c() > 100)
        {
            rst = "金融系结局";
        }
        else if (role.getMathmatic_c() > 100)
        {
            rst = "数学系结局";
        }
        return rst;
    }
    public static string getResults()
    {
        return thisSemester.generateResults();
    }
    public static List<int> Copy(List<int> target)
    {
        List<int> output = new List<int>();
        foreach (int a in target)
        {
            output.Add(a);
        }
        return output;
    }
}
