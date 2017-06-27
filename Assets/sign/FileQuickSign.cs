using System.IO;
using System.Text;

public static class FileQuickSign
{
    private static long[] m_IndexList16 = new long[16];
    private static long[] m_IndexList8 = new long[8];
    private static long[] m_IndexList4 = new long[4];
    private static StringBuilder m_Resutl;

    public static string GenSign32(string file)
    {
        if(!File.Exists(file))
        {
            return null;
        }
        FileInfo info = new FileInfo(file);
        long fileLength = info.Length;
        m_Resutl = new StringBuilder();

        FileStream fileStream = new FileStream(file, FileMode.Open);
        // begin
        m_IndexList16[0] = 0;
        m_IndexList16[1] = 1;
        m_IndexList16[2] = 2;
        m_IndexList16[3] = 3;

        // end
        m_IndexList16[12] = fileLength - 4;
        m_IndexList16[13] = fileLength - 3;
        m_IndexList16[14] = fileLength - 2;
        m_IndexList16[15] = fileLength - 1;

        int tmpCount = 8;
        for(int i=4;i<12;++i)
        {
            m_IndexList16[i] = fileLength / tmpCount * i;
        }

        for(int i=0;i<m_IndexList16.Length;++i)
        {
            m_Resutl.Append(GetFileContentByIndex(fileStream,m_IndexList16[i], fileLength));
        }
        fileStream.Close();

        return m_Resutl.ToString();
    }
    public static string GenSign16(string file)
    {
        if (!File.Exists(file))
        {
            return null;
        }
        FileInfo info = new FileInfo(file);
        long fileLength = info.Length;
        m_Resutl = new StringBuilder();

        FileStream fileStream = new FileStream(file, FileMode.Open);
        // begin
        m_IndexList8[0] = 0;
        m_IndexList8[1] = 1;

        // end
        m_IndexList8[6] = fileLength - 2;
        m_IndexList8[7] = fileLength - 1;

        int tmpCount = 4;
        for (int i = 2; i < 6; ++i)
        {
            m_IndexList8[i] = fileLength / tmpCount * i;
        }

        for (int i = 0; i < m_IndexList8.Length; ++i)
        {
            m_Resutl.Append(GetFileContentByIndex(fileStream, m_IndexList8[i], fileLength));
        }
        fileStream.Close();

        return m_Resutl.ToString();
    }
    public static string GenSign8(string file)
    {
        if (!File.Exists(file))
        {
            return null;
        }
        FileInfo info = new FileInfo(file);
        long fileLength = info.Length;
        m_Resutl = new StringBuilder();

        FileStream fileStream = new FileStream(file, FileMode.Open);
        // begin
        m_IndexList4[0] = 0;

        // end
        m_IndexList4[3] = fileLength - 1;

        int tmpCount = 4;
        for (int i = 1; i < 3; ++i)
        {
            m_IndexList4[i] = fileLength / tmpCount * i;
        }

        for (int i = 0; i < m_IndexList4.Length; ++i)
        {
            m_Resutl.Append(GetFileContentByIndex(fileStream, m_IndexList4[i], fileLength));
        }
        fileStream.Close();

        return m_Resutl.ToString();
    }
    private static int GetFileContentByIndex(FileStream fileStream, long index,long length)
    {
        if(index >= length)
        {
            index = length - 1;
        }
        if(index < 0)
        {
            index = 0;
        }
        fileStream.Seek(index, SeekOrigin.Begin);
        return fileStream.ReadByte();
    }
}
