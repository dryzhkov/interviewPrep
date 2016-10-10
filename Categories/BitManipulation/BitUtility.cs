namespace CodingInterviewPrep.BitManipulation {
  public class BitUtility {

    public static bool getBit(int num, int i) {
      int bitMask = 1 << i;
      return (num & bitMask) != 0;
    }

    public static int setBit(int num, int i) {
      int bitMask = 1 << i;
      return num | bitMask;
    }

    public static int clearBit(int num, int i) {
      int bitMask = ~(1 << i);
      return num & bitMask;
    }

    public static int clearMSBthroughI(int num, int i) {
      int bitMask = (1 << i) - 1;
      return num & bitMask;
    }

    public static int clearZeroBitToI(int num, int i) {
      int bitMask = -1 << (i + 1);
      return num & bitMask;
    }

    public static int updateBit(int num, int i, bool bitIs1) {
      if (bitIs1) {
        return setBit(num, i);
      } else {
        return clearBit(num, i);
      }
    }

    public static int insertMintoNat(int n, int m, int i, int j) {
      int left = -1 << (j + 1);
      int right = ~(-1 << i);
      int bitMask = left | right;
      int n2 = n  & bitMask;
      int m2 = m << i;
      return n2 | m2;
    }
  }
}