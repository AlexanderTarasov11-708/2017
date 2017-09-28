namespace Pluralize
{
    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            /**
             * "рублей" - 0; %100 = 11 .. 19 ; %10 = 5 .. 9 
             * "рубль" - %10 = 1;
             * "рубля" - %10 = 2 .. 4
             **/
            
            //отбрасываю ненужные разряды
            count = count % 100;                
            
            //заходит в if, если число %100 /= 11..19
            if (count / 10 != 1)                
            {
                if (count % 10 == 1)
                    return "рубль";             // %10 = 1 (но не %100 = 11 .. 19)
                else if (count % 10 == 2 || 
                            count % 10 == 3 || 
                                count % 10 == 4)
                    return "рубля";             // %10 = 2 .. 4 (но не %100 = 11 .. 19)
            }
            return "рублей";                    // %100 = 11 .. 19 и всё оставшееся: 0; %10 = 5 .. 9 
        }
    }
}