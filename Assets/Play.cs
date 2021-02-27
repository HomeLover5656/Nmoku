using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    int[,,] Masume = new int[10, 10, 10];
    int[,,] Value = new int[11, 10, 10];
    int[] A = new int[4];
    int x, y, z,i,j,k,a,b,c,d,e,f,g,h,turnnum=1,n;
    public int starter=1,lvl=2;
    double deray=0;
    public bool PlayerTurn;
    bool Continue = true;
    public GameObject CubePrefab,WinText,LoseText,Turn,WhichTurn;
    public Text TurnText,WhichTurnText;
    GameObject[,,] Cubes = new GameObject[10,10,10];
    GameObject Buttons;
    public Material[] Materials;

    //�{�^�����������Ƃ��̋����i�I�𒆂̃L���[�u�̍X�V�j�@
    //�O�̑I���L���[�u�̐F��Masume�̒l0(defo) or 1(player) or 2(computer) �ɖ߂�
    //�I�𒆃L���[�u�̐F��Masume+3�ɂ���B
    public void Xclick()
    {
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
        x += 1;
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]+4];
    }
    public void X_click()
    {
        Cubes[x%n, y%n, z%n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
        x += n-1;
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n] + 4];
    }
    public void Yclick()
    {
        Cubes[x% n, y% n, z% n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
        y += 1;
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n] + 4];
    }
    public void Y_click()
    {
        Cubes[x% n, y% n, z% n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
        y += n-1;
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n] + 4];
    }
    public void Zclick()
    {
        Cubes[x% n, y% n, z% n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
        z += 1;
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n] + 4];
    }
    public void Z_click()
    {
        Cubes[x% n, y% n, z% n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
        z += n-1;
        Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n] + 4];
    }

    //���s�𔻒肷��֐��i��������Ȃ�1,�Ȃ��Ȃ�0��Ԃ�)
    int Judge(int l)
    {
        a = b = c = d = e = f = g = 1;
        for (h = 0; h < n; h++)
        {
            a *= Masume[h, y% n, z% n];
            b *= Masume[x% n, h, z% n];
            c *= Masume[x% n, y% n, h];
            d *= Masume[h, n-1 - h, z % n];
            e *= Masume[x % n, h, n-1 - h];
            f *= Masume[n-1 - h, y % n, h];
        }
        if (a == l || b == l || c == l)
        {
            return (1);
        }
        if (x % n == n-1 - y % n && d == l) { return (1); }
        if (y % n == n-1 - z % n && e == l) { return (1); }
        if (z % n == n-1 - x % n && f == l) { return (1); }

            a = b = c = d = e = f = g = 1;

        for (h = 0; h < n; h++)
        {
            a *= Masume[h, h, z % n];
            b *= Masume[h, y % n, h];
            c *= Masume[x % n, h, h];
            d *= Masume[h, h, n-1 - h];
            e *= Masume[h, n-1 - h, h];
            f *= Masume[n-1 - h, h, h];
            g *= Masume[h, h, h];
        }
        if (x % n == y % n || y % n == z % n)
        {
            if (g == l) { return (1); }
        }
        if (x % n == y % n)
        {
            if (a == l) { return (1); }
            if (x % n == n-1 - z % n && d == l) { return (1); }
        }
        if (x % n == z % n)
        {
            if (b == l) { return (1); }
            if (x % n == n-1 - y % n && e == l) { return (1); }
        }
        if (y % n == z % n)
        {
            if (c == l) { return (1); }
            if (n-1 - x % n == y % n && f == l) { return (1); }
        }
            
        return (0);
    }

    //����{�^�����������Ƃ��̋���
    //�Ƃ肠����player��1,computer��2�ɂ��Ƃ�
    public void Det()
    {
        if (PlayerTurn)
        {
            if (Masume[x % n, y % n, z % n] == 0)
            {
                Masume[x % n, y % n, z % n] = 1;
                Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
                if (Judge(1) == 1)
                {
                    WinText.SetActive(true);
                    Continue = false;
                    PlayerTurn = false;
                }
                if (starter == 2)
                {
                    turnnum++;
                    TurnText.text = turnnum + "���";
                }
                x = y = z = 1;
                WhichTurnText.text = "�R���s���[�^�[�̃^�[��";
                PlayerTurn = false;
            }
            else
            {
                //�L�������@�X�Ɂu�����͑I���ł��܂���v
            }
        }
        else
        {
            if (Masume[x % n, y % n, z % n] == 0)
            {
                PlayerTurn = true;
                Masume[x % n, y % n, z % n] = 2;
                Cubes[x % n, y % n, z % n].GetComponent<Renderer>().sharedMaterial = Materials[Masume[x % n, y % n, z % n]];
                for (i = 0, j = 1; i < n; i++) { j *= 2; }
                if (Judge(j) == 1)
                {
                    LoseText.SetActive(true);
                    Continue = false;
                    PlayerTurn = false;
                }
                if (starter == 1)
                {
                    turnnum++;
                    TurnText.text = turnnum + "���";
                }
                x = y = z = 1;
                WhichTurnText.text = "���Ȃ��̃^�[��";
            }
            else
            {

            }
        }
    }

    //���ꂼ��̃}�X�ڂ̉��lvalue[,,]//�Ə���A[]//�����߂�֐��i�R���s���[�^�[�p�j�h���[����ɂ��g��
    void Eval()
    {
        Value[n,0,0] = -1;
        A[0] = A[1] = A[2] = n * n * n;

        void count(int e, int f,int g)
        {
            switch (Masume[e,f,g])
            {
                case 0:
                    a += 1;
                    break;
                case 1:
                    b += 1;
                    break;
                case 2:
                    c += 1;
                    break;
                case 3:
                    d += 1;
                    break;
            }
        }
        void COUNT()
        {
            if ((b >= 1 && c >= 1)||d >= 1) Value[i,j,k] += 0;
            else if (a == 1)
            {
                if (b == 0) Value[i,j,k] += 3056;     //�ő�(�łĂΏ���)
                else if (c == 0) Value[i,j,k] += 235;
            }//���_(�ł��Ȃ��ƕ�����)
            else if (b == 0) Value[i,j,k] += c * 2 + 1;
            else if (c == 0) Value[i,j,k] += b + 1;
        }

        //��������Acount()��COUNT()���g����value[i,j,k]�ɂ��ꂼ���masume[i,j,k]�̉��l�����Ă���
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                for (k = 0; k < n; k++)
                {
                    if (Masume[i,j,k] == 0)
                    {
                        //i,j,k��z�� I[3]�Ƃ��u�����炱�̏���for���ł������肵�����B
                        Value[i,j,k] = 0;
                        a = b = c = d = 0;
                        for (h= 0; h < n; h++) count(h,j,k);
                        COUNT();

                        a = b = c = d = 0;
                        for (h = 0; h < n; h++) count(i,h,k);
                        COUNT();

                        a = b = c = d = 0;
                        for (h = 0; h < n; h++) count(i, j, h);
                        COUNT();

                        //�d�����l���邩��else�͎g��Ȃ�
                        if (i==j)
                        {
                            a = b = c = d = 0;
                            for (h = 0; h < n; h++) count(h,h,k);
                            COUNT();

                            if (j == k)
                            {
                                a = b = c = d = 0;
                                for (h = 0; h < n; h++) count(h, h, h);
                                COUNT();
                            }
                            if(j==n-1-k)
                            {
                                a = b = c = d = 0;
                                for (h = 0; h < n; h++) count(h, h, n-1 - h);
                                COUNT();
                            }
                        }

                        if (i==n-1-j)
                        {
                            a = b = c = d = 0;
                            for (h = 0; h < n; h++) count(h, n-1 - h,k);
                            COUNT();

                            if (j == k)
                            {
                                a = b = c = d = 0;
                                for (h = 0; h < n; h++) count(h, n-1 - h, n-1 - h);
                                COUNT();
                            }
                            if (i == k)
                            {
                                a = b = c = d = 0;
                                for (h = 0; h < n; h++) count(h, n-1 - h, h);
                                COUNT();
                            }
                        }

                        if (j == k)
                        {
                            a = b = c = d = 0;
                            for (h = 0; h < n; h++) count(i, h, h);
                            COUNT();
                        }

                        if (j == n-1 - k)
                        {
                            a = b = c = d = 0;
                            for (h = 0; h < n; h++) count(i, h, n-1 - h);
                            COUNT();
                        }

                        if (k == i)
                        {
                            a = b = c = d = 0;
                            for (h = 0; h < n; h++) count(h, j, h);
                            COUNT();
                        }

                        if (k == n-1 - i)
                        {
                            a = b = c = d = 0;
                            for (h = 0; h < n; h++) count(n-1 - h, j, h);
                            COUNT();
                        }
                        
                    }

                    else Value[i,j,k] = -1;
                }
            }
        }

        //value[A2/n][A2%n](=�ő�) > value[A1/n][A1%n] > value[A0/n][A0%n]�@�ɂȂ�悤��
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                for (k = 0; k < n; k++)
                {
                    if (Value[i, j, k] >= Value[A[2] / (n * n), (A[2] % (n*n)) / n, A[2] % n])
                    {
                        A[0] = A[1];
                        A[1] = A[2];
                        A[2] = n * n * i + n * j + k;
                    }
                    else if (Value[i, j, k] >= Value[A[1] / (n*n), (A[1] % (n*n)) / n, A[1] % n])
                    {
                        A[0] = A[1];
                        A[1] = n * n * i + n * j + k;
                    }
                    else if (Value[i, j, k] >= Value[A[0] / (n*n), (A[0] % (n*n)) / n, A[0] % n])
                    {
                        A[0] = n * n * i + n * j + k;
                    }
                }
            }
        }

        if (Value[A[1]/(n*n),(A[1]%(n*n)) / n,A[1] % n] == -1) A[1] = A[2];
        if (Value[A[0]/(n*n),(A[0]%(n*n)) / n,A[0] % n] == -1) A[0] = A[1];
    }



    // Start is called before the first frame update
    void Start()
    {
        n = StartBut.n;
        lvl = StartBut.lvl;
        starter = StartBut.starter;
        if (starter == 1)
        {
            PlayerTurn = true;
            WhichTurnText.text = "���Ȃ��̃^�[��";
        }
        else
        {
            PlayerTurn = false;
            WhichTurnText.text = "�R���s���[�^�[�̃^�[��";
        }

        Buttons = GameObject.Find("Buttons");
        WinText.SetActive(false);
        LoseText.SetActive(false);

        //�L���[�u�̏����z�u
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                for (k = 0; k < n; k++)
                {
                    Cubes[i, j, k] = Instantiate(CubePrefab) as GameObject;
                    Cubes[i, j, k].transform.position = new Vector3(i+0.5f*(1.0f-n), j+ 0.5f * (1.0f - n), k+ 0.5f * (1.0f - n));
                    Masume[i, j, k] = 0;
                }
            }
        }
        x = y = z = 0;

        //�^�񒆂̃L���[�u��I��s�\�ɂ�����
        if (StartBut.noncenter)
        {
            if (n % 2 == 0)
            {

                Masume[n / 2, n / 2, n / 2] = 3;
                Cubes[n / 2, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2-1, n / 2, n / 2] = 3;
                Cubes[n / 2-1, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2, n / 2-1, n / 2] = 3;
                Cubes[n / 2, n / 2-1, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2, n / 2, n / 2-1] = 3;
                Cubes[n / 2, n / 2, n / 2-1].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2-1, n / 2-1, n / 2] = 3;
                Cubes[n / 2-1, n / 2-1, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2, n / 2-1, n / 2-1] = 3;
                Cubes[n / 2, n / 2-1, n / 2-1].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2-1, n / 2, n / 2-1] = 3;
                Cubes[n / 2-1, n / 2, n / 2-1].GetComponent<Renderer>().sharedMaterial = Materials[3];
                Masume[n / 2-1, n / 2-1, n / 2-1] = 3;
                Cubes[n / 2-1, n / 2-1, n / 2-1].GetComponent<Renderer>().sharedMaterial = Materials[3];
            }
            else
            {
                Masume[n / 2, n / 2, n / 2] = 3;
                Cubes[n / 2, n / 2, n / 2].GetComponent<Renderer>().sharedMaterial = Materials[3];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Buttons.gameObject.SetActive(PlayerTurn);
        if (PlayerTurn == false && Continue)
        {
           
            Eval();
            i = A[lvl] / (n*n);
            j = (A[lvl]%(n*n)) / n;
            k = A[lvl] % n;
            deray += Time.deltaTime;
            if (x% n != i)
            {
                if (deray > 1)
                {
                    deray = 0;
                    Xclick();
                }
            }
            else if (y% n != j)
            {
                if (deray > 1)
                {
                    deray = 0;
                    Yclick();
                }
            }
            else if (z% n != k)
            {
                if (deray > 1)
                {
                    deray = 0;
                    Zclick();
                }
            }
            else
            {
                deray = 0;
                Det();
            }

        }
    }
}
