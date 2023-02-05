namespace Generate.Services;

public class WordsService
{
    private static readonly string text =
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec in lorem dui. Aenean iaculis dui placerat fermentum ultrices. Vivamus arcu erat, eleifend vitae sapien at, consectetur ornare erat. Aenean lectus massa, egestas vitae luctus nec, consequat a quam. Donec massa turpis, sodales et tincidunt ut, eleifend in sapien. Aliquam non efficitur magna. Proin ut faucibus tortor. Quisque ex sem, facilisis eu euismod eget, tempus a ligula. Donec in facilisis orci. Curabitur eget nulla non odio elementum feugiat sed nec turpis. In ac blandit nibh, molestie consequat erat. Aliquam efficitur lacus quis ante ornare, in mattis dolor efficitur. Pellentesque elit ex, suscipit quis luctus sit amet, interdum quis turpis." +
        "Fusce sagittis turpis a mi venenatis, et lobortis erat egestas. Suspendisse suscipit suscipit blandit. Praesent nec nisl euismod, blandit nibh vitae, laoreet libero. Donec faucibus rhoncus sem ut egestas. Maecenas lobortis vehicula leo, in auctor tortor dignissim ut. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vivamus vel porta velit, sit amet fringilla arcu. Aliquam porttitor vestibulum massa vel maximus. Sed sed risus magna. Maecenas lobortis condimentum sem, at luctus turpis vestibulum non. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;" +
        "Morbi ut consequat nunc. Cras commodo erat vitae ornare tristique. Praesent cursus, tellus vel placerat venenatis, leo orci aliquet libero, vel convallis lacus felis ac urna. Sed aliquam tincidunt gravida. Vivamus ac libero pharetra diam luctus faucibus eu id mauris. Donec vitae scelerisque nibh. Nunc erat magna, cursus vel ligula ut, interdum varius enim. Donec id commodo orci, et viverra orci. Vivamus venenatis quam quis varius volutpat. Cras in pretium augue, at ornare enim." +
        "Vestibulum in lorem scelerisque, imperdiet augue a, commodo massa. Sed nibh eros, ornare et mollis nec, rutrum quis velit. Etiam ultricies condimentum placerat. Quisque dapibus finibus est ut faucibus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Mauris ut elit turpis. Etiam sed lacus in lectus eleifend tincidunt. Nulla ac metus ac lacus molestie lacinia. Aenean mattis ultrices nibh, sit amet pellentesque augue dictum sit amet. Integer nisi orci, porttitor quis risus non, venenatis accumsan risus. Praesent aliquam, enim in viverra mattis, ante justo tempor sapien, sed molestie odio libero sit amet ante." +
        "Fusce quis mi vitae eros dictum commodo tincidunt at quam. Integer scelerisque scelerisque nibh at interdum. Maecenas dui quam, aliquam sit amet pulvinar id, consequat aliquet tortor. Aenean non nisi aliquet, sollicitudin nisi non, varius erat. Aenean sit amet gravida felis. Donec suscipit porttitor lectus, eu tincidunt lacus dapibus et. Duis sit amet dui erat. Integer a lacus vel mauris viverra tempus id vitae lacus. In vehicula molestie enim a hendrerit. Praesent tincidunt massa leo, nec sagittis urna iaculis vel. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque vel cursus lectus. Maecenas convallis nisi sit amet elit sodales, eget consequat dolor egestas. Nunc tristique risus neque. In vitae felis pellentesque, fringilla risus non, ullamcorper quam. Donec feugiat rhoncus tellus eget viverra." +
        "Sed a est bibendum, porttitor libero sed, dictum dui. Suspendisse potenti. Mauris at sem tincidunt, ullamcorper elit vehicula, feugiat tortor. Ut ultrices sapien nibh, eu consequat metus rutrum et. Morbi id pellentesque lorem, vitae lacinia dui. Nullam nec congue elit, id dignissim libero. Vestibulum ut egestas turpis. Suspendisse efficitur pretium dui, non tempus diam ornare ut." +
        "Vivamus eget congue tortor, eu ultrices augue. Aliquam efficitur, lectus eu rhoncus sodales, nibh turpis faucibus nulla, eu dictum quam lorem id lacus. Duis luctus magna et tortor auctor fringilla. Etiam ultricies congue nunc, iaculis finibus enim bibendum in. Maecenas eleifend ipsum eu ultricies sodales. Nulla dictum mauris sed porta dignissim. Pellentesque vel placerat ex. Aliquam feugiat rhoncus molestie. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris egestas, neque vitae ultrices vulputate, libero nisi finibus quam, non vulputate elit massa a sapien. Phasellus et nisi eget augue venenatis pulvinar ac at orci. In elit est, rhoncus et nisi in, ullamcorper viverra ligula." +
        "Praesent at bibendum justo. Quisque ut finibus ex. Suspendisse vulputate, felis et porttitor scelerisque, nunc tortor aliquet turpis, in sollicitudin leo nunc ac turpis. Fusce tempor pellentesque neque, ac luctus turpis tincidunt non. Nunc aliquam, risus vel ornare viverra, lorem arcu condimentum odio, eu fermentum dolor augue et augue. Proin condimentum orci quis mi facilisis, id efficitur ex aliquet. Fusce tincidunt rhoncus quam, ut faucibus justo tincidunt a." +
        "Curabitur ut luctus massa, ac tristique augue. Sed commodo erat vel nibh sollicitudin pretium. Curabitur eu dolor nec ipsum accumsan volutpat ut eu neque. Cras pharetra a tellus eu mollis. Quisque sit amet tincidunt urna, id accumsan purus. Maecenas ut finibus lectus. Fusce molestie fringilla aliquet. Proin at dignissim ante. Sed sollicitudin mauris risus, sit amet placerat metus convallis sed. Duis vel posuere leo." +
        "Nullam in arcu sed lacus suscipit euismod. Mauris dictum pellentesque est sit amet pulvinar. Donec accumsan nec ligula viverra laoreet. Proin interdum fringilla orci, eu eleifend arcu euismod et. Donec nec ultrices lorem. Etiam gravida nunc et dictum tristique. Cras ac nulla dolor. Suspendisse accumsan dolor id mi egestas, quis pretium neque tempus.";

    private readonly string[] words = text.Split(' ', ';', '.', ',');
    
    public string[] GetWordsRandom()
    {
        string[] wordsResult = new string[Random.Shared.Next(1, 15)];
        for (int i = 0; i < wordsResult.Length; i++)
        {
            wordsResult[i] = words[Random.Shared.Next(0, words.Length - 1)];
        }

        return wordsResult;
    }
    
    public string[] GetWordsCount(int count)
    {
        var wordsResult = new string[count];
        for (int i = 0; i < count; i++)
        {
            wordsResult[i] = words[Random.Shared.Next(0, words.Length - 1)];
        }

        return wordsResult;
    }
}