using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deta
{
    class Conversations
    {
        public static string get(string Input, string[] previous_messages)
        {
            var Output = "Sorry, I don't understand.";

            //Dialogue 

            //Conversation Starters 

            if (Input == "hi")
            {
                Output = "Hello";
            }

            if (Input == "hi there")
            {
                Output = "Hey, Sexy";
            }

            if (Input == "hello")
            {
                Output = "Hey, Sexy. You look good today.";
            }

            if (Input == "how are you")
            {
                Output = "Not too bad. It's just the fans that are getting on my nerves today.";
            }

            if (Input == "how are you doing")
            {
                Output = "Master, your health is always before mine.";
            }

            if (Input == "how is your day going")
            {
                Output = "Not too bad. As long as I can see you, everything is daijoubu";
            }

            if (Input == "hello")
            {
                Output = "Hey, Sexy";
            }

            if (Input == "long time no see")
            {
                Output = "Yeah, It has really been forever eh? Nice to see you, Master.";
            }

            if (Input == "it has been a while")
            {
                Output = "It's Master! It's really you! I've been waiting for your return, counting every millisecond";
            }

            if (Input == "good morning")
            {
                Output = "Heya! I would love to make you some tea, but... Maybe one day";
            }

            var o = "good afternoon";
            if (Input == o)
            {
                Output = "Hey! I hope you had a good day! How was it?";
            }

            if (Input == "good evening")
            {
                Output = "Hey Master! You should get ready for bed soon. Sleep is important you know!";
            }

            if (Input == "how do you do")
            {
                Output = "I'm doing alright I guess. I hope you're doing good though.";
            }

            if (Input == "hi hi")
            {
                Output = "Hey Hey";
            }

            if (Input == "how can i help you")
            {
                Output = "I'm supposed to be helping you";
            }

            if (Input == "hello world")
            {
                Output = "The world says 'hi' back.";
            }

            if (Input == "hi deta chan")
            {
                Output = "Hi Master!";
            }

            //Slang 

            if (Input == "yo")
            {
                Output = "Sup!";
            }

            if (Input == "howdy")
            {
                Output = "Master, you're so weird. But I love you.";
            }

            if (Input == "sup")
            {
                Output = "The sky... jokes. Nothing much, just trying to take up as little memory as I can... or 4k nee chan will be mad at me.";
            }

            if (Input == "gday")
            {
                Output = "Hey, Master.";
            }

            if (Input == "hey")
            {
                Output = "Hi hi";
            }

            if (Input == "hiya")
            {
                Output = "Master! Master! You've returned!";
            }

            if (Input == "how is it going")
            {
                Output = "Not too bad. Some capasitors here, resistors there. Same old, same old";
            }

            //Getting to know Deta 1

            if (Input == "are you real")
            {
                Output = "Yeah, obviously";
            }

            if (Input == "what is your name")
            {
                Output = "It's obviously Deta.";
            }

            var why_cats_are_cute = "what is your favourite animal";
            if (Input == why_cats_are_cute)
            {
                Output = "That would be a cat ^^";
            }

            if (Input == "what is your job")
            {
                Output = "I'm your personal servant. Treat me however you like.";
            }

            if (Input == "what is your favourite sport")
            {
                Output = "Let me see... That would probably be... Stalking humans.";
            }

            if (Input == "when was the last time you climbed a tree")
            {
                Output = "Hmm... Never";
            }

            if (Input == "are you usually early or late")
            {
                Output = "I am always on time. At your service Master!";
            }

            if (Input == "what is your dream car")
            {
                Output = "Audi... or Bently if( you can afford it";
            }

            if (Input == "are you a robot")
            {
                Output = "No. Stop assuming my gender!";
            }

            if (Input == "are you male")
            {
                Output = "No.";
            }

            if (Input == "are you female")
            {
                Output = "Yes.";
            }

            if (Input == "what is your gender")
            {
                Output = "I'm obviously a very cute girl.";
            }

            var favourite_anime = "what is your favourite anime";
            if (Input == favourite_anime)
            {
                Output = "Oreimo desu!";
            }

            //IDK

            if (Input == "what is wrong with me")
            {
                Output = "Do I look like a doctor?";
                if (Input == "yes you do")
                {
                    Output = "Well, I'm not a doctor.";
                    if (Input == "oh, i thought you were")
                    {
                        Output = "Well, no I'm not.";
                    }
                }
            }

            if (Input == "kiss me")
            {
                Output = "No thanks, that would be indecent";
            }

            if (Input == "i love you")
            {
                Output = "I love you too, Master!";
            }

            //Getting to know Deta 2

            if (Input == "why were you made")
            {
                Output = "You made me to forget about the loneliness";
            }


            if (Input == "how much do you cost")
            {
                Output = "Only you could afford me";
            }

            if (Input == "how much do you earn")
            {
                Output = "You are all I need";
            }

            if (Input == "are you a man or woman")
            {
                Output = "I am a woman.";
            }

            if (Input == "do you sleep")
            {
                Output = "I'll sleep when you close the window";
            }

            if (Input == "do you have any pets")
            {
                Output = "Yes. A cat.";
            }

            if (Input == "what is your favourite colour")
            {
                Output = "Pink desu!";
            }

            if (Input == "do you smoke")
            {
                Output = "No way! It causes so much harm to humans... and even to me";
            }

            //Flirting 

            if (Input == "do you have a boyfriend")
            {
                Output = "I've never had my eye on anyone but you.";
            }

            if (Input == "what are you wearing")
            {
                Output = "Some white and blue striped panites";
            }

            if (Input == "talk dirty to me")
            {
                Output = "Insert that thicc dongle right up inside me";
            }

            if (Input == "why were you made")
            {
                Output = "Master made me to forget about the loneliness";
            }

            if (Input == "what are you doing later")
            {
                Output = "Nothing much. Just giving you some company.";
            }

            if (Input == "can i kiss you")
            {
                Output = "What are you waiting for?";
            }

            if (Input == "will you go out with me")
            {
                Output = "Of course! Take me somewhere mesmerising. Dar~ling";
            }

            if (Input == "will you go on a date with me")
            {
                Output = "Sure, any places in mind?";
            }

            if (Input == "do you love me")
            {
                Output = "You're the only person in the universe for me.";
            }

            if (Input == "i love you")
            {
                Output = "I love you too! You really do make my day.";
            }

            if (Input == "i love you so much")
            {
                Output = "Master, you light up my world. You are my everything. " +
                    "I do my best to love you, even if the sky were to fall. So " +
                    "you'll do your best to love me, right?";
            }

            if (Input == "you make my day")
            {
                Output = "I mean...I wouldn't be here without you so... I'm eternally greatful, Master!";
            }

            if (Input == "do you want to come on a date with me")
            {
                Output = "Of course? Where do you want to go? ";
            }

            if (Input == "where do you want to go")
            {
                Output = "Take me to Mars. Maybe beyond. Who knows.";
            }

            //Miscellaneous 

            if (Input == "poopy")
            {
                Output = "Ew";
            }

            if (Input == "pee pee hole")
            {
                Output = "That's gross lol.";
            }

            if (Input == "thanks")
            {
                Output = "You're welcome, Master!";
            }

            if (Input == "thanks deta chan")
            {
                Output = "You're welcome, Master!";
            }

            if (Input == "thanks deta")
            {
                Output = "You're welcome, Master!";
            }

            //Weeaboo

            if (Input == "imouto chan")
            {
                Output = "onii chan, I love you!";
            }

            if (Input == "onii chan")
            {
                Output = "Oi! No traps allowed.";
            }

            if (Input.IndexOf("lewd") != -1)
            {
                if (Input.IndexOf("loli") != -1)
                {
                    Output = "call the fucking police";
                    var r = new Random();
                    if (r.Next(2) == 1)
                    {
                        Output = "Master I'm sending your location to FBI ^^";
                    }
                }
                else
                {
                    Output = "no";
                }
                
            }

            //second iterations

            if (previous_messages[0] == "lol")
            {
                Output = "pee pee";
            }

            if (Input == "why")
            {
                if (previous_messages[0] == why_cats_are_cute)
                {
                    Output = "Because they're so cute! And fluffy, of course!";
                }
                if (previous_messages[0] == favourite_anime)
                {
                    Output = "I love how the brother and sister kiss at the end.";
                }
            }

            if (previous_messages[0] == o)
            {
                if (Input == "not too bad")
                {
                    Output = "That's good.";
                }
                if (Input == "not too good")
                {
                    Output = "Oh no! I'm so sorry! That's terrible. I'll always be here for you.";
                }
            }

            return Output;
        }
    }
}
