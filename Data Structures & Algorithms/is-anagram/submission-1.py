class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s) != len(t):
            return False

        nb_char_s = {}
        nb_char_t = {}

        for value in s :
            if value not in nb_char_s :
                nb_char_s[value] = 1
            else :
                nb_char_s[value]+=1

        for value in t :
            if value not in nb_char_s :
                return False
            
            if value not in nb_char_t :
                nb_char_t[value] = 1
            else : 
                nb_char_t[value]+= 1
            
            if nb_char_t[value] > nb_char_s[value] :
                return False
        
        return True