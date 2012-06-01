using System;
using System.Collections.Generic;
using System.Text;

namespace TermoPrinterLib
{
    public class PPU700ControlCommands
    {
    }

    public enum PrintControlCommand
    {
        LF =        0x000a,
        CR =        0x000d,
        FF =        0x000c,
        ESC_FF =    0x1b0c, 
        ESC_J_n =   0x1b4a, 
        ESC_d_n =   0x1b64, 
    }

    public enum PrintCharacterCommand
    {
        CAN =                   0x0018,
        ESC_SP_n =              0x1b20, 
        ESC_Exclamation_n =     0x1b21, // ESC ! n
        ESC_Percent_n =         0x1b25, // ESC % n
        ESC_Minus_n =           0x1b2d, // ESC - n
        ESC_Question_n =        0x1b3f, // ESC ? n
        ESC_E_n =               0x1b45, 
        ESC_G_n =               0x1b47, 
        ESC_M_n =               0x1b4d,
        ESC_R_n =               0x1b52,
        ESC_V_n =               0x1b56,
        ESC_t_n =               0x1b74,
        ESC_Bracket_n =         0x1b7b, // ESC { n
        GS_Exclamation_n =      0x1d21, // GS ! n
        GS_B_n =                0x1d42, 
        GS_b_n =                0x1d62
    }

    public enum PrintPositionCommand
    {
        HT =                    0x0009,
        ESC_Exclamation_n1_n2 = 0x1b24, // ESC ! n1 n2
        ESC_T_n =               0x1b54,
        ESC_W =                 0x1b57, // ESC W xL xH yL yH dxL dxH dyL dyH    - Defining the print area in PAGE MODE
        ESC_Backslash_nL_nH =   0x1b5c, // ESC \ nL nH                          - Specifying the relative position
        ESC_a_n =               0x1b61,
        GS_DollarSign_nL_nH =   0x1d24, // GS $ nL nH
        GS_L_nL_nH =            0x1d4c,
        GS_T_n =                0x1d54,
        GS_W_nL_nH =            0x1d57,
        GS_Backslash_nL_nH =    0x1d5c // GS \ nL nH
    }

    public enum LineFeedSpanCommand
    {
        ESC_2 =     0x1b32,
        ESC_3_n =   0x1b33
    }

    public enum BitImageCommand
    {
        ESC_Star =              0x1b2a // ESC * m n1 n2 [d]k
        //
    }

    public enum StatusCommand
    {
        DLE_EOT_n =             0x1004,
        ESC_v =                 0x1b76,
        GS_a_n =                0x1d61,
        GS_r_n =                0x1d72
    }

    public enum PaperDetectingCommand
    {
        ESC_c_3_n = 0x1b6333,
        ESC_c_4_n = 0x1b6334,
        ESC_c_5_n = 0x1b6335
    }

    public enum MacroCommand
    {
        GS_TwoDots =            0x1d3a, // GS :
        GS_Hat_n1_n2_n3 =       0x1d5e // GS ^ n1 n2 n3
    }

    public enum CutterCommand
    {
        ESC_I =     0x1b69,
        ESC_m =     0x1b6d,
        GS_V =      0x1d56 // 1)GS V m   2)GS V m n
    }

    public enum BarCodeCommand
    {
        GS_H_n =    0x1d48,
        GS_f_n =    0x1d66,
        GS_h_n =    0x1d68,
        GS_k =      0x1d6b,
        GS_w_n =    0x1d77
    }

    public enum SpecialCommand
    {
        ESC_n_n =       0x1b6e,
        ESC_Y_n1_n2 =   0x1b59
        //
    }

    public enum OtherCommand
    {
        DLE_ENQ_n =         0x1005,
        DLE_DC4_fn_m_t =    0x1014, 
        ESC_Equal_n =       0x1b3d, // ESC = n
        ESC_Dog =           0x1b40, // ESC @
        ESC_L =             0x1b4c,
        ESC_S =             0x1b53,
        ESC_RS =            0x1b1e,
        GS_Bracket =        0x1d28, // GS ( A pL pH n m
        GS_I_n =            0x1d49,
        GS_P_x_y =          0x1d50
    }
}
