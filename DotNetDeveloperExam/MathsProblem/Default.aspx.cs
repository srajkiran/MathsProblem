using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    #region PageEvents

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion

    #region Control Events

    protected void btnGo_Click(object sender, EventArgs e)
    {
        #region Variables

        long iN1 = 0;
        long iD1 = 0;
        long iN2 = 0;
        long iD2 = 0;
        long k = 0;
        long l = 0;
        long i = 0;
        long lsa = 1;
        long iD1M = 0;
        long iD2M = 0;
        
        long sum = 0;
        long diff = 0;
        long proN = 0;
        long proD = 0;
        long div = 0;

        long iQ1 = 0;
        long iR1 = 0;
        long iQ2 = 0;
        long iR2 = 0;

        #endregion

        #region Get Numerator & Denominator

        string[] input1;
        string[] input2;

        if (txtInput1.Text != "")
        {
            input1 = txtInput1.Text.Split('/');
            long.TryParse(input1[0].ToString(), out iN1);
            long.TryParse(input1[1].ToString(), out iD1);
        }

        if (txtInput2.Text != "")
        {
            input2 = txtInput2.Text.Split('/');
            long.TryParse(input2[0].ToString(), out iN2);
            long.TryParse(input2[1].ToString(), out iD2);
        }

        #endregion

        #region Get LSA

        k = iD1;
        l = iD2;
        i = 2;

        while ((k != 1) || (l != 1))
        {
            if (k % i == 0 || l % i == 0)
            {
                if (k % i == 0)
                    k = k / i;
                if (l % i == 0)
                    l = l / i;

                lsa = lsa * i;
            }
            else
            {
                i++;
            }
        }

        #endregion

        #region Check Numerator & Denominator is Divisible

        for (int j = 2; j < lsa; j++)
        {
            if ((iN1 % j == 0) && (iD1 % j == 0) && iN1 != 0)
            {
                iN1 = iN1 / j;
                iD1 = iD1 / j;
            }

            if ((iN2 % j == 0) && (iD2 % j == 0) && iN2 != 0)
            {
                iN2 = iN2 / j;
                iD2 = iD2 / j;
            }
        }

        #endregion

        #region Get String For Answer Of Fraction Input

        if (iN1 > iD1)
        {
            iQ1 = iN1 / iD1;
            iR1 = iN1 % iD1;
        }

        if (iN2 > iD2)
        {
            iQ2 = iN2 / iD2;
            iR2 = iN2 % iD2;
        }

        string iN1Str = string.Empty;
        if (iN1 > iD1)
            iN1Str = (iN1 < 0 ? "(" + iQ1.ToString() + " " + iR1.ToString() + (iD1 == 1 ? "" : "/" + iD1.ToString()) + ")" : iQ1.ToString() + " " + iR1.ToString() + (iD1 == 1 ? "" : "/" + iD1.ToString()));
        else
            iN1Str = (iN1 < 0 ? "(" + iN1.ToString() + (iD1 == 1 ? "" : "/" + iD1.ToString()) + ")" : iN1.ToString() + (iD1 == 1 ? "" : "/" + iD1.ToString()));

        string iN2Str = string.Empty;
        if (iN2 > iD2)
            iN2Str = (iN2 < 0 ? "(" + iQ2.ToString() + " " + iR2.ToString() + (iD2 == 1 ? "" : "/" + iD2.ToString()) + ")" : iQ2.ToString() + " " + iR2.ToString() + (iD2 == 1 ? "" : "/" + iD2.ToString()));
        else
            iN2Str = (iN2 < 0 ? "(" + iN2.ToString() + (iD2 == 1 ? "" : "/" + iD2.ToString()) + ")" : iN2.ToString() + (iD2 == 1 ? "" : "/" + iD2.ToString()));

        #endregion

        #region Get Maultiplier To Equal LSA
        
        for (int j = 1; k != lsa; j++)
        {
            k = iD1;
            k = k * j;
            iD1M = j;
        }

        for (int j = 1; l != lsa; j++)
        {
            l = iD2;
            l = l * j;
            iD2M = j;
        }

        #endregion

        #region Get SUM

        sum = ((iN1 * iD1M) + (iN2 * iD2M));
        long iSumQ = 0;
        long iSumR = 0;
        long lsaS = lsa;

        if (Math.Abs(sum) > lsa)
        {
            iSumQ = sum / lsa;
            iSumR = Math.Abs(sum % lsa);

            for (int j = 2; j < lsa; j++)
            {
                if ((iSumR % j == 0) && (lsaS %j == 0) && iSumR != 0)
                {
                    iSumR = iSumR / j;
                    lsaS = lsaS / j;
                }
            }
        }

        string sumStr = string.Empty;
        if (Math.Abs(sum) > lsa)
            sumStr = (sum < 0 ? "(" + iSumQ.ToString() + " " + iSumR.ToString() + "/" + lsaS.ToString() + ")" : iSumQ.ToString() + " " + iSumR.ToString() + "/" + lsaS.ToString());
        else
            sumStr = (sum < 0 ? "(" + sum.ToString() + "/" + lsaS.ToString() + ")" : sum.ToString() + "/" + lsaS.ToString());

        lblSum.Text = iN1Str + " + " + iN2Str + " = " + sumStr;

        #endregion

        #region Get Difference

        diff = ((iN1 * iD1M) - (iN2 * iD2M));
        long iDiffQ = 0;
        long iDiffR = 0;
        long lsaD = lsa;

        if (Math.Abs(diff) > lsa)
        {
            iDiffQ = diff / lsa;
            iDiffR = Math.Abs(diff % lsa);

            for (int j = 2; j < lsa; j++)
            {
                if ((iDiffR % j == 0) && (lsaD % j == 0) && iDiffR != 0)
                {
                    iDiffR = iDiffR / j;
                    lsaD = lsaD / j;
                }
            }
        }

        string diffStr = string.Empty;
        if (Math.Abs(diff) > lsa)
            diffStr = (diff < 0 ? "(" + iDiffQ.ToString() + " " + iDiffR.ToString() + "/" + lsaD.ToString() + ")" : iDiffQ.ToString() + " " + iDiffR.ToString() + "/" + lsaD.ToString());
        else
            diffStr = (diff < 0 ? "(" + diff.ToString() + "/" + lsaD.ToString() + ")" : diff.ToString() + "/" + lsaD.ToString());

        lblDiff.Text = iN1Str + " - " + iN2Str + " = " + diffStr;

        #endregion

        #region Get Product

        proN = iN1 * iN2;
        proD = iD1 * iD2;
        long iProQ = 0;
        long iProR = 0;
        long lsaP = proD;

        for (int j = 2; j < proD; j++)
        {
            if ((proN % j == 0) && (proD % j == 0) && proN != 0)
            {
                proN = proN / j;
                lsaP = lsaP / j;
            }
        }

        if (Math.Abs(proN) > proD)
        {
            iProQ = proN / proD;
            iProR = Math.Abs(proN % proD);

            for (int j = 2; j < proD; j++)
            {
                if ((iProR % j == 0) && (lsaP % j == 0) && iProR != 0)
                {
                    iProR = iProR / j;
                    lsaP = lsaP / j;
                }
            }
        }

        string proStr = string.Empty;
        if (Math.Abs(proN) > proD)
            proStr = (proN < 0 ? "(" + iProQ.ToString() + " " + iProR.ToString() + "/" + lsaP.ToString() + ")" : iProQ.ToString() + " " + iProR.ToString() + "/" + lsaP.ToString());
        else
            proStr = (proN < 0 ? "(" + proN.ToString() + "/" + lsaP.ToString() + ")" : proN.ToString() + "/" + lsaP.ToString());

        lblProduct.Text = iN1Str + " * " + iN2Str + " = " + proStr;

        #endregion

        #region Get Division

        //div = (iN1 * iD2) / (iN2 * iD1);
        if (iN2 * iD1 == 0)
        {
            lblQuotient.Text = "Inf";
        }
        else
        {
            lblQuotient.Text = "";
        }

        #endregion

    }

    #endregion
}