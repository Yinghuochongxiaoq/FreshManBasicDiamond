﻿using System.Collections.Generic;
using System.Linq;
using FreshManBasicDiamond.Sort;

namespace FreshManBasicDiamondTest.SortTest
{
    public class MoreSortTest
    {
        /// <summary>
        /// 测试用的排序数据
        /// </summary>
        private readonly List<int> _sortData;

        /// <summary>
        /// 测试用的排序数据
        /// </summary>
        public List<int> SortData
        {
            get { return _sortData.Select(f => f).ToList(); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MoreSortTest()
        {
            _sortData = new List<int> { 42, 20, 17, 13, 28, 14, 23, 15, 74, 14, 86, 29, 94, 57, 97, 83, 39, 71, 80, 66, 43, 20, 3, 15, 38, 20, 35, 19, 63, 80, 8, 46, 39, 10, 93, 43, 44, 93, 39, 97, 36, 78, 34, 20, 10, 48, 89, 79, 77, 6, 85, 39, 91, 35, 33, 16, 88, 18, 10, 61, 57, 44, 60, 77, 39, 69, 23, 86, 97, 62, 69, 48, 29, 5, 66, 73, 66, 30, 57, 57, 54, 98, 23, 40, 29, 29, 29, 3, 99, 14, 85, 65, 84, 46, 74, 55, 61, 41, 54, 100, 18, 30, 31, 15, 93, 23, 14, 70, 74, 27, 51, 84, 46, 67, 72, 52, 88, 28, 10, 91, 30, 52, 65, 63, 6, 63, 40, 21, 98, 25, 49, 6, 96, 97, 52, 62, 71, 84, 85, 55, 60, 29, 86, 40, 28, 11, 42, 88, 96, 78, 38, 16, 37, 45, 44, 0, 79, 13, 14, 79, 65, 38, 98, 60, 61, 29, 26, 24, 59, 36, 0, 88, 8, 85, 60, 97, 89, 50, 79, 92, 42, 44, 67, 16, 78, 99, 64, 7, 94, 54, 50, 78, 60, 95, 73, 23, 14, 45, 14, 44, 11, 54, 80, 78, 80, 3, 9, 9, 43, 71, 59, 48, 0, 92, 83, 14, 54, 9, 70, 38, 77, 28, 92, 40, 57, 21, 98, 47, 45, 68, 50, 47, 30, 13, 84, 17, 47, 37, 57, 33, 45, 45, 27, 53, 54, 16, 67, 78, 20, 90, 30, 16, 36, 53, 86, 78, 73, 48, 32, 68, 0, 45, 27, 47, 66, 56, 49, 10, 55, 21, 39, 84, 47, 89, 62, 72, 5, 31, 71, 67, 43, 64, 3, 77, 6, 89, 64, 54, 38, 14, 81, 32, 69, 49, 90, 72, 86, 59, 64, 15, 64, 88, 71, 41, 2, 0, 31, 30, 89, 70, 19, 89, 96, 58, 32, 33, 7, 53, 46, 5, 44, 51, 4, 9, 33, 100, 6, 95, 93, 43, 35, 62, 39, 14, 18, 51, 4, 35, 41, 22, 86, 68, 100, 26, 73, 42, 49, 1, 34, 63, 7, 88, 82, 72, 75, 36, 18, 85, 13, 100, 68, 34, 34, 13, 38, 57, 1, 16, 22, 41, 99, 14, 58, 28, 73, 94, 46, 58, 44, 42, 17, 30, 94, 99, 52, 100, 1, 53, 33, 6, 14, 63, 1, 67, 6, 75, 20, 62, 96, 21, 83, 47, 2, 74, 49, 32, 34, 41, 37, 77, 69, 81, 22, 63, 19, 25, 4, 99, 16, 41, 37, 26, 71, 46, 55, 54, 86, 88, 22, 16, 40, 46, 58, 47, 23, 8, 27, 11, 22, 15, 99, 22, 65, 93, 29, 31, 51, 54, 58, 14, 96, 71, 54, 49, 76, 50, 93, 9, 15, 89, 51, 73, 94, 47, 87, 60, 44, 98, 71, 8, 50, 70, 77, 84, 66, 25, 66, 45, 29, 46, 94, 67, 85, 19, 81, 72, 70, 37, 10, 47, 5, 2, 69, 24, 78, 69, 64, 86, 28, 46, 79, 31, 62, 82, 30, 8, 11, 45, 75, 54, 61, 39, 43, 50, 55, 45, 40, 37, 32, 5, 43, 60, 18, 88, 4, 69, 25, 37, 16, 19, 10, 46, 57, 43, 12, 44, 55, 73, 93, 26, 8, 51, 20, 12, 53, 14, 65, 98, 44, 48, 27, 33, 16, 82, 72, 98, 10, 88, 17, 37, 12, 80, 22, 75, 74, 78, 18, 50, 1, 70, 82, 36, 47, 40, 14, 76, 98, 53, 94, 84, 26, 31, 22, 79, 44, 57, 65, 15, 42, 39, 100, 93, 33, 56, 87, 26, 15, 77, 28, 68, 35, 75, 32, 40, 39, 28, 73, 68, 47, 51, 76, 79, 15, 58, 15, 19, 31, 21, 72, 33, 44, 73, 29, 46, 10, 63, 92, 72, 57, 34, 47, 60, 7, 51, 75, 20, 58, 53, 79, 91, 42, 17, 57, 82, 32, 11, 98, 65, 96, 43, 79, 13, 92, 79, 57, 1, 89, 41, 62, 41, 6, 60, 82, 74, 36, 95, 26, 62, 84, 61, 87, 26, 62, 45, 50, 6, 49, 23, 81, 62, 52, 1, 16, 76, 71, 31, 72, 83, 67, 62, 74, 52, 42, 29, 39, 62, 0, 45, 51, 23, 64, 11, 57, 59, 3, 34, 92, 27, 35, 5, 57, 4, 46, 90, 93, 44, 82, 29, 76, 51, 12, 21, 81, 94, 79, 34, 33, 76, 65, 77, 80, 99, 28, 42, 3, 31, 23, 41, 47, 0, 68, 76, 89, 89, 35, 40, 86, 55, 13, 2, 4, 60, 68, 52, 3, 45, 87, 93, 37, 14, 15, 66, 70, 86, 38, 63, 6, 23, 11, 12, 86, 28, 56, 27, 20, 88, 76, 5, 9, 39, 86, 56, 13, 17, 85, 40, 85, 96, 73, 62, 17, 28, 6, 92, 90, 76, 80, 79, 49, 41, 97, 18, 72, 57, 41, 20, 49, 43, 55, 68, 27, 59, 80, 35, 63, 33, 22, 2, 97, 58, 25, 29, 0, 51, 35, 39, 40, 26, 0, 0, 72, 88, 86, 85, 48, 98, 4, 87, 36, 84, 25, 76, 88, 35, 27, 43, 88, 39, 77, 53, 57, 62, 80, 50, 48, 96, 9, 24, 44, 10, 94, 90, 15, 16, 11, 11, 83, 90, 60, 52, 42, 95, 99, 57, 16, 21, 71, 68, 37, 67, 58, 17, 83, 92, 9, 4, 57, 66, 27, 49, 63, 70, 56, 70, 14, 51, 38, 33, 16, 30, 80, 68, 36, 48, 82, 17, 50, 4, 94, 94, 75, 76, 29, 72, 17, 54, 70, 46, 88, 52, 2, 70, 16, 38, 39, 42, 23, 26, 53, 37, 56, 55, 24, 12, 42, 87, 51, 72, 8, 71, 66, 98, 85, 77, 27, 67, 7, 65, 6, 72, 19, 63, 97, 99, 32, 2, 92, 15, 67, 41, 65, 67, 83, 74, 75, 4, 97, 38, 44, 17, 41, 5, 16, 71, 99, 84, 99, 15, 85, 77, 61, 59, 71, 2, 61, 39, 23, 10, 55, 2, 87, 39, 83, 45, 90, 34, 47, 5, 14, 44, 99, 21, 86, 98, 94, 62, 26, 41, 8791, 4383, 7182, 7589, 2600, 9219, 2400, 3751, 2345, 3202, 6321, 9507, 3982, 2843, 8542, 5843, 5314, 8475, 4551, 5228, 4710, 3502, 2742, 6409, 4537, 1910, 5217, 6796, 4040, 6014, 7488, 6864, 2574, 3802, 4960, 5427, 7585, 5701, 4719, 4864, 5890, 8999, 4071, 4380, 2345, 646, 6806, 1199, 5543, 9809, 3548, 2199, 1127, 3086, 5957, 3845, 1978, 6726, 3468, 8779, 7334, 1450, 6633, 6144, 6559, 8532, 6027, 2731, 4250, 2243, 5303, 4725, 8254, 7707, 4490, 5701, 7797, 4915, 2597, 5164, 8001, 9491, 4513, 5450, 1175, 9515, 7035, 8446, 3599, 3247, 7708, 1611, 5031, 6683, 594, 8206, 4525, 1811, 4614, 3503, 4774, 6366, 4199, 3464, 2768, 1939, 2932, 5548, 2248, 3619, 4367, 5943, 5365, 6650, 6918, 9164, 7213, 9601, 4279, 7586, 2964, 8265, 4600, 7007, 5395, 1447, 7281, 9777, 5753, 6416, 4097, 1078, 4421, 9424, 7874, 930, 2268, 3108, 6917, 8624, 9126, 5793, 4221, 1139, 1576, 3335, 4639, 7153, 6625, 1121, 8013, 4892, 8006, 3245, 3625, 8267, 5626, 753, 7364, 8264, 5264, 624, 6197, 1369, 3527, 4510, 7627, 8657, 2988, 5125, 5788, 1030, 9166, 4856, 233, 5378, 7243, 8931, 7422, 1811, 763, 2000, 9611, 3819, 7380, 896, 651, 9670, 4407, 3133, 6551, 1134, 9420, 1508, 1589, 9994, 6123, 7605, 5168, 1613, 9913, 4741, 6431, 3256, 9489, 3850, 2647, 7710, 1796, 3356, 9293, 9086, 5830, 3712, 5146, 6464, 7566, 5229, 5061, 9298, 4895, 2135, 7239, 5062, 5546, 4172, 2600, 6795, 2299, 3324, 6023, 1449, 3831, 8230, 1011, 154, 2282, 6553, 4551, 3171, 3701, 980, 6243, 9791, 1091, 4052, 6759, 4224, 6775, 8213, 8315, 9117, 6079, 7312, 2146, 7422, 1878, 7030, 5335, 7165, 9431, 7287, 6614, 6306, 9051, 4186, 4696, 4686, 3197, 1091, 7345, 8781, 1827, 8841, 7142, 2265, 1512, 6046, 2420, 4046, 9193, 1972, 2530, 4853, 359, 8388, 4617, 5722, 7278, 7547, 2374, 5707, 3004, 8837, 211, 445, 140, 3606, 8131, 7643, 2420, 6786, 4070, 2381, 78, 2999, 2231, 8039, 5127, 4190, 6405, 2667, 3888, 8005, 5854, 4147, 8120, 1170, 3694, 9130, 5427, 6631, 462, 7591, 459, 49, 3630, 9714, 937, 7472, 7695, 718, 2543, 3853, 2860, 1523, 5649, 9440, 3857, 6100, 5153, 8204, 2489, 5554, 9056, 7813, 2258, 8403, 3481, 3932, 3069, 5060, 7863, 5364, 9309, 4074, 6508, 1958, 4322, 5988, 8139, 6427, 2199, 379, 3870, 8375, 7653, 410, 5138, 2529, 5187, 6604, 9317, 3267, 2845, 2826, 7072, 6379, 4350, 8336, 1714, 9664, 3069, 8960, 9913, 8019, 6098, 6871, 3582, 5570, 4496, 1790, 786, 3045, 8757, 8548, 7083, 2790, 6506, 3344, 8979, 1171, 5673, 3568, 2277, 502, 4182, 1958, 602, 6076, 9494, 2304, 9380, 8387, 4112, 7819, 5167, 2165, 158, 1765, 5825, 8376, 963, 9394, 4464, 1425, 7570, 3271, 5654, 5699, 2425, 2889, 7358, 974, 9309, 9343, 2140, 1019, 5401, 9608, 3105, 4308, 1427, 7057, 1121, 3043, 5577, 1929, 519, 8571, 2961, 6950, 593, 4803, 2155, 2791, 5652, 9648, 7224, 8744, 3640, 279, 3340, 2845, 6028, 7200, 8206, 6935, 3580, 7677, 3868, 367, 77, 3106, 7103, 6146, 1245, 9769, 9979, 8271, 2199, 2454, 5847, 5251, 3599, 5668, 3985, 1989, 7259, 8716, 7581, 4970, 9220, 236, 2255, 5195, 771, 3363, 5628, 2253, 3940, 2571, 2715, 3931, 5620, 6109, 4960, 8932, 9506, 8703, 2134, 7621, 7036, 6387, 4441, 5812, 3990, 8898, 4725, 8726, 6109, 7187, 2541, 6885, 8565, 4102, 6047, 5622, 3234, 2072, 2381, 5986, 9699, 2387, 5326, 1948, 9139, 3526, 9720, 1122, 7811, 9012, 2197, 705, 231, 2516, 3849, 6004, 8706, 3585, 4730, 6840, 286, 8266, 1862, 3452, 9341, 4815, 7957, 6156, 6792, 6977, 5618, 9795, 2853, 1105, 7772, 3849, 6289, 5519, 9332, 6879, 1329, 9675, 7182, 9690, 249, 7157, 4201, 3089, 73, 3183, 9555, 8986, 5066, 6594, 9828, 2755, 455, 5148, 7854, 1445, 1674, 6028, 5206, 8798, 9398, 8979, 8963, 3851, 1944, 7825, 1365, 1763, 6712, 6140, 9108, 7383, 2636, 6292, 4432, 7740, 7978, 913, 362, 9167, 9682, 3550, 6047, 4814, 3793, 4588, 8386, 2256, 360, 265, 2125, 221, 4451, 4115, 8465, 1444, 1291, 6673, 4685, 555, 2248, 3541, 7678, 8145, 4782, 3703, 3559, 6306, 2812, 9229, 9060, 6987, 8594, 7085, 6547, 6914, 2319, 3075, 8158, 6479, 8276, 1494, 3083, 8359, 7784, 7261, 1818, 9002, 8242, 6193, 5340, 8569, 9150, 8021, 3479, 4844, 4296, 8269, 675, 33, 6121, 6144, 3553, 9518, 8610, 510, 1022, 9588, 9111, 1779, 588, 4655, 4508, 7570, 3741, 8540, 8382, 693, 2833, 2458, 4225, 1011, 1475, 3072, 1799, 9360, 5594, 1510, 9153, 7977, 9258, 5147, 5255, 58, 6752, 148, 2502, 1362, 3699, 4460, 2213, 7532, 2541, 2375, 2211, 2377, 6654, 4846, 3111, 5410, 7312, 4511, 3541, 9086, 9546, 581, 4824, 8972, 7249, 7369, 620, 3906, 8294, 125, 1250, 1048, 658, 2845, 3289, 1978, 1480, 2530, 8946, 4167, 2679, 8604, 7159, 3404, 3639, 6899, 5382, 1802, 9097, 8276, 5637, 4701, 3663, 6613, 7729, 7401, 9729, 2535, 3167, 832, 3615, 5162, 5241, 9612, 1589, 6345, 7831, 9243, 5600, 1530, 1212, 321, 4928, 1655, 5516, 8532, 9279, 4603, 629, 1911, 3318, 6545, 1753, 3490, 1276, 3232, 7183, 7510, 5668, 2281, 1544, 6969, 9083, 6109, 4089, 830, 7039, 5117, 4211, 7619, 5931, 2791, 3716, 8644, 4761, 1821, 3383, 2121, 8056, 7353, 9356, 9191, 2531, 3958, 5428, 7050, 7516, 5043, 4783, 9440, 9189, 9594, 3915, 7374, 6572, 944, 2853, 5701, 8003, 2410, 7064, 6322, 14, 630, 8192, 4660, 8661, 1943, 7151, 311, 185, 1041, 6590, 5824, 1368, 5740, 2830, 1043, 6394, 6334, 1719, 7254, 7449, 1212, 6263, 277, 1292, 6976, 3613, 3457, 7066, 3499, 2940, 5017, 1074, 8673, 9511, 1869, 5916, 8115, 2450, 6985, 6112, 9968, 7607, 8101, 7100, 5153, 1281, 708, 9894, 3632, 7790, 8741, 137, 5587, 8374, 8430, 8854, 6701, 246, 8310, 1626, 1410, 4331, 6089, 1468, 7653, 4385, 8638, 9380, 9305, 48, 3022, 5269, 5468, 6445, 8215, 9529, 6179, 9852, 526, 8876, 9769, 26, 2420, 8962, 8163, 6010, 5009, 9722, 4756, 2783, 3799, 849, 9936, 4247, 584, 9290, 6942, 2008, 3680, 3966, 4111, 4109, 913, 5100, 6034, 1380, 4535, 4495, 5637, 4618, 7167, 3287, 8551, 1468, 8188, 1300, 2481, 5069, 3530, 7354, 2414, 1954, 8146, 3191, 4755, 7156, 5890, 4978, 2155, 2277, 7599, 3275, 7435, 1497, 7195, 7167, 3173, 9588, 6550, 3685, 2099, 7898, 8781, 5637, 7660, 3444, 6928, 3064, 6457, 2381, 4636, 6641, 2530, 7152, 3879, 2093, 5366, 74, 14, 86, 29, 94, 57, 97, 83, 39, 71, 80, 66, 43, 20, 3, 15, 38, 20, 35, 19, 63, 80, 8, 46, 39, 10, 93, 43, 44, 93, 39, 97, 36, 78, 34, 20, 10, 48, 89, 79, 77, 6, 85, 39, 91, 35, 33, 16, 88, 18, 10, 61, 57, 44, 60, 77, 39, 69, 23, 86, 97, 62, 69, 48, 29, 5, 66, 73, 66, 30, 57, 57, 54, 98, 23, 40, 29, 29, 29, 3, 99, 14, 85, 65, 84, 46, 74, 55, 61, 41, 54, 100, 18, 30, 31, 15, 93, 23, 14, 70, 74, 27, 51, 84, 46, 67, 72, 52, 88, 28, 10, 91, 30, 52, 65, 63, 6, 63, 40, 21, 98, 25, 49, 6, 96, 97, 52, 62, 71, 84, 85, 55, 60, 29, 86, 40, 28, 11, 42, 88, 96, 78, 38, 16, 37, 45, 44, 0, 79, 13, 14, 79, 65, 38, 98, 60, 61, 29, 26, 24, 59, 36, 0, 88, 8, 85, 53816, 90892, 99196, 79615, 57304, 90305, 68004, 56743, 22089, 30226, 19386, 54392, 58050, 39393, 16165, 50143, 17934, 43968, 29576, 52290, 84381, 58662, 50501, 10061, 82099, 99352, 65976, 85292, 83402, 75161, 33997, 57365, 59416, 38983, 75410, 76177, 94763, 53981, 82593, 60103, 32959, 25340, 71222, 14941, 25634, 62899, 42192, 61571, 48642, 39657, 36986, 13014, 84579, 51933, 58482, 84876, 31418, 13970, 68400, 63114, 72409, 21435, 88864, 10986, 32616, 46574, 83082, 18847, 39515, 53454, 91844, 24515, 94684, 76600, 90617, 55038, 98077, 29333, 93838, 41572, 99039, 44041, 26518, 26350, 98580, 20895, 50722, 45485, 81243, 17828, 29556, 27069, 45853, 33977, 38985, 22779, 90672, 66614, 24092, 51853, 58354, 31323, 69633, 34301, 14067, 56904, 54308, 90751, 66702, 58301, 24740, 44989, 10957, 20004, 27561, 49826, 71373, 11908, 29258, 52726, 61796, 14283, 10102, 85162, 26286, 68870, 73322, 93805, 29910, 32506, 79436, 29634, 82968, 99573, 49749, 22610, 58831, 51467, 29246, 24425, 41259, 34063, 21073, 21414, 43691, 17741, 33664, 58682, 33308, 76071, 40319, 72146, 35674, 45879, 46150, 24059, 21178, 26477, 59899, 77363, 25854, 44674, 32007, 78300, 22461, 36536, 42098, 92404, 81943, 92370, 86309, 93214, 64787, 95477, 40483, 33545, 55776, 74764, 79437, 67094, 84024, 73878, 17126, 33181, 87452, 53820, 24229, 32645, 24915, 46307, 89005, 24943, 37995, 26484, 98599, 57724, 26700, 16746, 18249, 74173, 30205, 43516, 39285, 64519, 88768, 22106, 93512, 87512, 49550, 99966, 95790, 85865, 28178, 78064, 66656, 34034, 48968, 16025, 52683, 96029, 55990, 29453, 16226, 73186, 49733, 82884, 77636, 17183, 88924, 40023, 26184, 84964, 56254, 65718, 99084, 17139, 68732, 32925, 23121, 77538, 10893, 48455, 27190, 92634, 41698, 17724, 23402, 56604, 21784, 66328, 69892, 22432, 46760, 72382, 12491, 71724, 35860, 81397, 42325, 90150, 64094, 33405, 71631, 70532, 65057, 12405, 60257, 17049, 62842, 24328, 12559, 49094, 30470, 30146, 75283, 64228, 54833, 63782, 95467, 89325, 11318, 25201, 27831, 89712, 39086, 44383, 13741, 42458, 39288, 45369, 31508, 57304, 75937, 64382, 10589, 99667, 18514, 32746, 51948, 32998, 76523, 23346, 96243, 28027, 21086, 63606, 77129, 17126, 75359, 93037, 79875, 11065, 46573, 12716, 50877, 31962, 86989, 81952, 23641, 50382, 46041, 80658, 67553, 23815, 87752, 93344, 72684, 63719, 38514, 63670, 12098, 94505, 34547, 13464, 72940, 44159, 22413, 90321, 92571, 99915, 98128, 87847, 55020, 56259, 31030, 55912, 77154, 87439, 46836, 54899, 80799, 53719, 32564, 89352, 14473, 93436, 30869, 94738, 23316, 49468, 33688, 47221, 31253, 55537, 55844, 62675, 60001, 90732, 69660, 93729, 64185, 17592, 97646, 97497, 91970, 55670, 57716, 75560, 16186, 34626, 51494, 59243, 41207, 27701, 59902, 42916, 58600, 20914, 49694, 41856, 70467, 88387, 42278, 54358, 86471, 44435, 70172, 54003, 32028, 33716, 39721, 74413, 91987, 89584, 99454, 38808, 36367, 52766, 16499, 60126, 55739, 54014, 37440, 11980, 81233, 81512, 10153, 84486, 27178, 67309, 71622, 20630, 46962, 43586, 31219, 89785, 50698, 12980, 91638, 13310, 48064, 44593, 57865, 75990, 89367, 17818, 61529, 89421, 27794, 56516, 12686, 57037, 72111, 95177, 42000, 88000, 39548, 35710, 17501, 32154, 12404, 13453, 15468, 51653, 12848, 25487, 43846, 30462, 29559, 45214, 84255, 41724, 97812, 20373, 14258, 49359, 50302, 24106, 94396, 65928, 31427, 79658, 90695, 61937, 44123, 79832, 46926, 92939, 40764, 27369, 10578, 13176, 25774, 65570, 63413, 39689, 88128, 31608, 65490, 81630, 76871, 78842, 90711, 76876, 56248, 73099, 36428, 27389, 75845, 75422, 46273, 27999, 96305, 82714, 46410, 54489, 13676, 48330, 17220, 31584, 71127, 63023, 94218, 54549, 82780, 79800, 99247, 67432, 80254, 38403, 50770, 53371, 18198, 12381, 43641, 61313, 31123, 75296, 46118, 94098, 49243, 86891, 27481, 74962, 95917, 65792, 92751, 58772, 86996, 75800, 80578, 31422, 21883, 29867, 42875, 13426, 69541, 16141, 10143, 52707, 93917, 95226, 57145, 97401, 45037, 87699, 95369, 62024, 33735, 96319, 94049, 30047, 46534, 48264, 53675, 55611, 89438, 73440, 75645, 64132, 86288, 58848, 27941, 21695, 47509, 29127, 98608, 85670, 71788, 68584, 93047, 28342, 99327, 71319, 54209, 14921, 85378, 92516, 98535, 92217, 14830, 68387, 54224, 37619, 20141, 39315, 55670, 93969, 44393, 73736, 48678, 58866, 32892, 21555, 76303, 80167, 82040, 56933, 84350, 18918, 29478, 87547, 35869, 26290, 95732, 42249, 33111, 66347, 64452, 95152, 39116, 24819, 83178, 69011, 42439, 26823, 28618, 46542, 61829, 73208, 33461, 13970, 98709, 51302, 79854, 22578, 14883, 34025, 24109, 49167, 39796, 11702, 88715, 60763, 71459, 28138, 90005, 45437, 17677, 88406, 27689, 72509, 43969, 12122, 92103, 90080, 78155, 61396, 20793, 42369, 37443, 26836, 37023, 27882, 42359, 36620, 89553, 81283, 76980, 40792, 91790, 59458, 81258, 28636, 20017, 55269, 61988, 66734, 71205, 13657, 96299, 22381, 16201, 95459, 28968, 66767, 54167, 26915, 99672, 12429, 96186, 64873, 57649, 54552, 79346, 46712, 65830, 97471, 72096, 77629, 33266, 36194, 34463, 62137, 15691, 57638, 91621, 74465, 28482, 38499, 45307, 54905, 50600, 25938, 60822, 67109, 29573, 93034, 91159, 91739, 34075, 56158, 36902, 24979, 38362, 44637, 97200, 51756, 43112, 89014, 92996, 67420, 13418, 22521, 96089, 72944, 54663, 82489, 14284, 64153, 38116, 49142, 78989, 83178, 21942, 21984, 58819, 65938, 60343, 22663, 81110, 24975, 89396, 96353, 75305, 34489, 81147, 30534, 69065, 16565, 51131, 36001, 92894, 74960, 82602, 16495, 60752, 24688, 55674, 42713, 31463, 86311, 50583, 42252, 41319, 96933, 34183, 95494, 11801, 79295, 23810, 61026, 62878, 27035, 59423, 58846, 47796, 86106, 78823, 20377, 81076, 83952, 90004, 55502, 12549, 20098, 64510, 89996, 59203, 53743, 21131, 54307, 62271, 92210, 15549, 29465, 93155, 40867, 36586, 56806, 26704, 91383, 73927, 81826, 15632, 43829, 42415, 95211, 74128, 71249, 71813, 91459, 57409, 60969, 58426, 48768, 15177, 83064, 41665, 15051, 10073, 98421, 89163, 70055, 15544, 80168, 50031, 18008, 71446, 67025, 44492, 32541, 31192, 86750, 36820, 90337, 49041, 21114, 99804, 28293, 77764, 73691, 45791, 35439, 65008, 98415, 31192, 11293, 81704, 29443, 23208, 33152, 80200, 31812, 31423, 40591, 61833, 27184, 78768, 45122, 81557, 16120, 54832, 55764, 76835, 78795, 26763, 83170, 39648, 34699, 22858, 28442, 52382, 21310, 71304, 75049, 33805, 57571, 59793, 69111, 23477, 31216, 88815, 57429, 35217, 59676, 23446, 82138, 83129, 70022, 51480, 55938, 26922, 63491, 56838, 26973, 24605, 85610, 91238, 55782, 33872, 42045, 74211, 96463, 28957, 64311, 14686, 49930, 49243, 97917, 27220, 58425, 47129, 18087, 76673, 67838, 99187, 76313, 83077, 69055, 28428, 68176, 80249, 58618, 84252, 23409, 15023, 82604, 14186, 43135, 77880, 54723, 93280, 89863, 24065, 29036, 25689, 59601, 92928, 48413, 78168, 13830, 44168, 96739, 49252, 35849, 37711, 53403, 12668, 95153, 90975, 30760, 81056, 98110, 42587, 38536, 71910, 44168, 69623, 91863, 63638, 30456, 73714, 61634, 90327, 45911, 76477, 49836, 83868, 77479, 90754, 51485, 72765, 70509, 15941, 30041, 72247, 19477, 17045, 44476, 67709, 73906, 67895, 76337, 24847, 69567, 52309, 95941, 71913, 45885, 60, 97, 89, 50, 79, 92, 42, 44, 67, 16, 78, 99, 64, 7, 94, 54, 50, 78, 60, 95, 73, 23, 14, 45, 14, 44, 11, 54, 80, 78, 80, 3, 9, 9, 43, 71, 59, 48, 0, 92, 83, 14, 54, 9, 70, 38, 77, 28, 92, 40, 57, 21, 98, 47, 45, 68, 50, 47, 30, 13, 84, 17, 47, 37, 57, 33, 45, 45, 27, 53, 54, 16, 67, 78, 20, 90, 30, 16, 36, 53, 86, 78, 73, 48, 32, 68, 0, 45, 27, 47, 66, 56, 49, 10, 55, 21, 39, 84, 47, 89, 62, 72, 5, 31, 71, 67, 43, 64, 3, 77, 6, 89, 64, 54, 38, 14, 81, 32, 69, 49, 90, 72, 86, 59, 64, 15, 64, 88, 71, 41, 2, 0, 31, 30, 89, 70, 19, 89, 96, 58, 32, 33, 7, 53, 46, 5, 44, 51, 4, 9, 33, 100, 6, 95, 93, 43, 35, 62, 39, 14, 18, 51, 4, 35, 41, 22, 86, 68, 100, 26, 73, 42, 49, 1, 34, 63, 7, 88, 82, 72, 75, 36, 18, 85, 13, 100, 68, 34, 34, 13, 38, 57, 1, 16, 22, 41, 99, 14, 58, 28, 73, 94, 46, 58, 44, 42, 17, 30, 94, 99, 52, 100, 1, 53, 33, 6, 14, 63, 1, 67, 6, 75, 20, 62, 96, 21, 83, 47, 2, 74, 49, 32, 34, 41, 37, 77, 69, 81, 22, 63, 19, 25, 4, 99, 16, 41, 37, 26, 71, 46, 55, 54, 86, 88, 22, 16, 40, 46, 58, 47, 23, 8, 27, 11, 22, 15, 99, 22, 65, 93, 29, 31, 51, 54, 58, 14, 96, 71, 54, 49, 76, 50, 93, 9, 15, 89, 51, 73, 94, 47, 87, 60, 44, 98, 71, 8, 50, 70, 77, 84, 66, 25, 66, 45, 29, 46, 94, 67, 85, 19, 81, 72, 70, 37, 10, 47, 5, 2, 69, 24, 78, 69, 64, 86, 28, 46, 79, 31, 62, 82, 30, 8, 11, 45, 75, 54, 61, 39, 43, 50, 55, 45, 40, 37, 32, 5, 43, 60, 18, 88, 4, 69, 25, 37, 16, 19, 10, 46, 57, 43, 12, 44, 55, 73, 93, 26, 8, 51, 20, 12, 53, 14, 65, 98, 44, 48, 27, 33, 16, 82, 72, 98, 10, 88, 17, 37, 12, 80, 22, 75, 74, 78, 18, 50, 1, 70, 82, 36, 47, 40, 14, 76, 98, 53, 94, 84, 26, 31, 22, 79, 44, 57, 65, 15, 42, 39, 100, 93, 33, 56, 87, 26, 15, 77, 28, 68, 35, 75, 32, 40, 39, 28, 73, 68, 47, 51, 76, 79, 15, 58, 15, 19, 31, 21, 72, 33, 44, 73, 29, 46, 10, 63, 92, 72, 57, 34, 47, 60, 7, 51, 75, 20, 58, 53, 79, 91, 42, 17, 57, 82, 32, 11, 98, 65, 96, 43, 79, 13, 92, 79, 57, 1, 89, 41, 62, 41, 6, 60, 82, 74, 36, 95, 26, 62, 84, 61, 87, 26, 62, 45, 50, 6, 49, 23, 81, 62, 52, 1, 16, 76, 71, 31, 72, 83, 67, 62, 74, 52, 42, 29, 39, 62, 0, 45, 51, 23, 64, 11, 57, 59, 3, 34, 92, 27, 35, 5, 57, 4, 46, 90, 93, 44, 82, 29, 76, 51, 12, 21, 81, 94, 79, 34, 33, 76, 65, 77, 80, 99, 28, 42, 3, 31, 23, 41, 47, 0, 68, 76, 89, 89, 35, 40, 86, 55, 13, 2, 4, 60, 68, 52, 3, 45, 87, 93, 37, 14, 15, 66, 70, 86, 38, 63, 6, 23, 11, 12, 86, 28, 56, 27, 20, 88, 76, 5, 9, 39, 86, 56, 13, 17, 85, 40, 85, 96, 73, 62, 17, 28, 6, 92, 90, 76, 80, 79, 49, 41, 97, 18, 72, 57, 41, 20, 49, 43, 55, 68, 27, 59, 80, 35, 63, 33, 22, 2, 97, 58, 25, 29, 0, 51, 35, 39, 40, 26, 0, 0, 72, 88, 86, 85, 48, 98, 4, 87, 36, 84, 25, 76, 88, 35, 27, 43, 88, 39, 77, 53, 57, 62, 80, 50, 48, 96, 9, 24, 44, 10, 94, 90, 15, 16, 11, 11, 83, 90, 60, 52, 42, 95, 99, 57, 16, 21, 71, 68, 37, 67, 58, 17, 83, 92, 9, 4, 57, 66, 27, 49, 63, 70, 56, 70, 14, 51, 38, 33, 16, 30, 80, 68, 36, 48, 82, 17, 50, 4, 94, 94, 75, 76, 29, 72, 17, 54, 70, 46, 88, 52, 2, 70, 16, 38, 39, 42, 23, 26, 53, 37, 56, 55, 24, 12, 42, 87, 51, 72, 8, 71, 66, 98, 85, 77, 27, 67, 7, 65, 6, 72, 19, 63, 97, 99, 32, 2, 92, 15, 67, 41, 65, 67, 83, 74, 75, 4, 97, 38, 44, 17, 41, 5, 16, 71, 99, 84, 99, 15, 85, 77, 61, 59, 71, 2, 61, 39, 23, 10, 55, 2, 87, 39, 83, 45, 90, 34, 47, 5, 14, 44, 99, 21, 86, 98, 94, 62, 26, 41, 8791, 4383, 7182, 7589, 2600, 9219, 2400, 3751, 2345, 3202, 6321, 9507, 3982, 2843, 8542, 5843, 5314, 8475, 4551, 5228, 4710, 3502, 2742, 6409, 4537, 1910, 5217, 6796, 4040, 6014, 7488, 6864, 2574, 3802, 4960, 5427, 7585, 5701, 4719, 4864, 5890, 8999, 4071, 4380, 2345, 646, 6806, 1199, 5543, 9809, 3548, 2199, 1127, 3086, 5957, 3845, 1978, 6726, 3468, 8779, 7334, 1450, 6633, 6144, 6559, 8532, 6027, 2731, 4250, 2243, 5303, 4725, 8254, 7707, 4490, 5701, 7797, 4915, 2597, 5164, 8001, 9491, 4513, 5450, 1175, 9515, 7035, 8446, 3599, 3247, 7708, 1611, 5031, 6683, 594, 8206, 4525, 1811, 4614, 3503, 4774, 6366, 4199, 3464, 2768, 1939, 2932, 5548, 2248, 3619, 4367, 5943, 5365, 6650, 6918, 9164, 7213, 9601, 4279, 7586, 2964, 8265, 4600, 7007, 5395, 1447, 7281, 9777, 5753, 6416, 4097, 1078, 4421, 9424, 7874, 930, 2268, 3108, 6917, 8624, 9126, 5793, 4221, 1139, 1576, 3335, 4639, 7153, 6625, 1121, 8013, 4892, 8006, 3245, 3625, 8267, 5626, 753, 7364, 8264, 5264, 624, 6197, 1369, 3527, 4510, 7627, 8657, 2988, 5125, 5788, 1030, 9166, 4856, 233, 5378, 7243, 8931, 7422, 1811, 763, 2000, 9611, 3819, 7380, 896, 651, 9670, 4407, 3133, 6551, 1134, 9420, 1508, 1589, 9994, 6123, 7605, 5168, 1613, 9913, 4741, 6431, 3256, 9489, 3850, 2647, 7710, 1796, 3356, 9293, 9086, 5830, 3712, 5146, 6464, 7566, 5229, 5061, 9298, 4895, 2135, 7239, 5062, 5546, 4172, 2600, 6795, 2299, 3324, 6023, 1449, 3831, 8230, 1011, 154, 2282, 6553, 4551, 3171, 3701, 980, 6243, 9791, 1091, 4052, 6759, 4224, 6775, 8213, 8315, 9117, 6079, 7312, 2146, 7422, 1878, 7030, 5335, 7165, 9431, 7287, 6614, 6306, 9051, 4186, 4696, 4686, 3197, 1091, 7345, 8781, 1827, 8841, 7142, 2265, 1512, 6046, 2420, 4046, 9193, 1972, 2530, 4853, 359, 8388, 4617, 5722, 7278, 7547, 2374, 5707, 3004, 8837, 211, 445, 140, 3606, 8131, 7643, 2420, 6786, 4070, 2381, 78, 2999, 2231, 8039, 5127, 4190, 6405, 2667, 3888, 8005, 5854, 4147, 8120, 1170, 3694, 9130, 5427, 6631, 462, 7591, 459, 49, 3630, 9714, 937, 7472, 7695, 718, 2543, 3853, 2860, 1523, 5649, 9440, 3857, 6100, 5153, 8204, 2489, 5554, 9056, 7813, 2258, 8403, 3481, 3932, 3069, 5060, 7863, 5364, 9309, 4074, 6508, 1958, 4322, 5988, 8139, 6427, 2199, 379, 3870, 8375, 7653, 410, 5138, 2529, 5187, 6604, 9317, 3267, 2845, 2826, 7072, 6379, 4350, 8336, 1714, 9664, 3069, 8960, 9913, 8019, 6098, 6871, 3582, 5570, 4496, 1790, 786, 3045, 8757, 8548, 7083, 2790, 6506, 3344, 8979, 1171, 5673, 3568, 2277, 502, 4182, 1958, 602, 6076, 9494, 2304, 9380, 8387, 4112, 7819, 5167, 2165, 158, 1765, 5825, 8376, 963, 9394, 4464, 1425, 7570, 3271, 5654, 5699, 2425, 2889, 7358, 974, 9309, 9343, 2140, 1019, 5401, 9608, 3105, 4308, 1427, 7057, 1121, 3043, 5577, 1929, 519, 8571, 2961, 6950, 593, 4803, 2155, 2791, 5652, 9648, 7224, 8744, 3640, 279, 3340, 2845, 6028, 7200, 8206, 6935, 3580, 7677, 3868, 367, 77, 3106, 7103, 6146, 1245, 9769, 9979, 8271, 2199, 2454, 5847, 5251, 3599, 5668, 3985, 1989, 7259, 8716, 7581, 4970, 9220, 236, 2255, 5195, 771, 3363, 5628, 2253, 3940, 2571, 2715, 3931, 5620, 6109, 4960, 8932, 9506, 8703, 2134, 7621, 7036, 6387, 4441, 5812, 3990, 8898, 4725, 8726, 6109, 7187, 2541, 6885, 8565, 4102, 6047, 5622, 3234, 2072, 2381, 5986, 9699, 2387, 5326, 1948, 9139, 3526, 9720, 1122, 7811, 9012, 2197, 705, 231, 2516, 3849, 6004, 8706, 3585, 4730, 6840, 286, 8266, 1862, 3452, 9341, 4815, 7957, 6156, 6792, 6977, 5618, 9795, 2853, 1105, 7772, 3849, 6289, 5519, 9332, 6879, 1329, 9675, 7182, 9690, 249, 7157, 4201, 3089, 73, 3183, 9555, 8986, 5066, 6594, 9828, 2755, 455, 5148, 7854, 1445, 1674, 6028, 5206, 8798, 9398, 8979, 8963, 3851, 1944, 7825, 1365, 1763, 6712, 6140, 9108, 7383, 2636, 6292, 4432, 7740, 7978, 913, 362, 9167, 9682, 3550, 6047, 4814, 3793, 4588, 8386, 2256, 360, 265, 2125, 221, 4451, 4115, 8465, 1444, 1291, 6673, 4685, 555, 2248, 3541, 7678, 8145, 4782, 3703, 3559, 6306, 2812, 9229, 9060, 6987, 8594, 7085, 6547, 6914, 2319, 3075, 8158, 6479, 8276, 1494, 3083, 8359, 7784, 7261, 1818, 9002, 8242, 6193, 5340, 8569, 9150, 8021, 3479, 4844, 4296, 8269, 675, 33, 6121, 6144, 3553, 9518, 8610, 510, 1022, 9588, 9111, 1779, 588, 4655, 4508, 7570, 3741, 8540, 8382, 693, 2833, 2458, 4225, 1011, 1475, 3072, 1799, 9360, 5594, 1510, 9153, 7977, 9258, 5147, 5255, 58, 6752, 148, 2502, 1362, 3699, 4460, 2213, 7532, 2541, 2375, 2211, 2377, 6654, 4846, 3111, 5410, 7312, 4511, 3541, 9086, 9546, 581, 4824, 8972, 7249, 7369, 620, 3906, 8294, 125, 1250, 1048, 658, 2845, 3289, 1978, 1480, 2530, 8946, 4167, 2679, 8604, 7159, 3404, 3639, 6899, 5382, 1802, 9097, 8276, 5637, 4701, 3663, 6613, 7729, 7401, 9729, 2535, 3167, 832, 3615, 5162, 5241, 9612, 1589, 6345, 7831, 9243, 5600, 1530, 1212, 321, 4928, 1655, 5516, 8532, 9279, 4603, 629, 1911, 3318, 6545, 1753, 3490, 1276, 3232, 7183, 7510, 5668, 2281, 1544, 6969, 9083, 6109, 4089, 830, 7039, 5117, 4211, 7619, 5931, 2791, 3716, 8644, 4761, 1821, 3383, 2121, 8056, 7353, 9356, 9191, 2531, 3958, 5428, 7050, 7516, 5043, 4783, 9440, 9189, 9594, 3915, 7374, 6572, 944, 2853, 5701, 8003, 2410, 7064, 6322, 14, 630, 8192, 4660, 8661, 1943, 7151, 311, 185, 1041, 6590, 5824, 1368, 5740, 2830, 1043, 6394, 6334, 1719, 7254, 7449, 1212, 6263, 277, 1292, 6976, 3613, 3457, 7066, 3499, 2940, 5017, 1074, 8673, 9511, 1869, 5916, 8115, 2450, 6985, 6112, 9968, 7607, 8101, 7100, 5153, 1281, 708, 9894, 3632, 7790, 8741, 137, 5587, 8374, 8430, 8854, 6701, 246, 8310, 1626, 1410, 4331, 6089, 1468, 7653, 4385, 8638, 9380, 9305, 48, 3022, 5269, 5468, 6445, 8215, 9529, 6179, 9852, 526, 8876, 9769, 26, 2420, 8962, 8163, 6010, 5009, 9722, 4756, 2783, 3799, 849, 9936, 4247, 584, 9290, 6942, 2008, 3680, 3966, 4111, 4109, 913, 5100, 6034, 1380, 4535, 4495, 5637, 4618, 7167, 3287, 8551, 1468, 8188, 1300, 2481, 5069, 3530, 7354, 2414, 1954, 8146, 3191, 4755, 7156, 5890, 4978, 2155, 2277, 7599, 3275, 7435, 1497, 7195, 7167, 3173, 9588, 6550, 3685, 2099, 7898, 8781, 5637, 7660, 3444, 6928, 3064, 6457, 2381, 4636, 6641, 2530, 7152, 3879, 2093, 5366 };
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        public void BubbleSortTest()
        {
            var list = SortData;
            var sortList = Sort.BubbleSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        public void SelectSortTest()
        {
            var list = SortData;
            var sortList = Sort.SelectSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        public void InsertSortTest()
        {
            var list = SortData;
            var sortList = Sort.InsertSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        public void ShellSortTest()
        {
            var list = SortData;
            var sortList = Sort.ShellSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        public void QuickSortTest()
        {
            var list = SortData;
            var sortList = Sort.QuickSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 二路归并排序
        /// </summary>
        public void MergeSortTest()
        {
            var list = SortData;
            var sortList = Sort.MergeSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        public void MinHeapSortTest()
        {
            var list = SortData;
            var sortList = Sort.MinHeapSort(list);
            sortList[2206].IsEqualTo(4040);
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        public void MaxHeapSortTest()
        {
            var list = SortData;
            var sortList = Sort.MaxHeapSort(list);
            sortList[2206].IsEqualTo(1175);
        }

        /// <summary>
        /// 基数排序
        /// </summary>
        public void RadixSortTest()
        {
            var list = SortData;
            var sortList = Sort.RadixSort(list, 5, 10);
            sortList[2206].IsEqualTo(1175);
        }
    }
}
