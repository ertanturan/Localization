# Unity-Localization

The tool is an internal localization system for unity-based projects with support of right-to-left (RTLL) translation. 


## Import

1. Go to [release](https://github.com/ertanturan/Unity-Localization/releases) page.
2. Download the lates release of the package.
3. Import it to your unity project.

## Abbrevations

LTR: Left To Right
RTL : Right To Left

## Installation

!! ATTENTION !! 
The release package is installed and set for 3 languages : Turkish , English and Arabic . The installation process below is for the ones who would like to add more languages to their system .

# Usage

1. Create `Assets/Resources/Data/Localization` folder if doesn't exists already.
2. Under Localization Folder >> Create 3 Folders named `AlphabetFontMatrix` , `Alphabets` and `Languages` if doesn't exits already.
3. Under Alphabets folder >> `Right click >> Create >> Localization >> Alphabet` (Create as many alphabets as you want).
4. Set RTL or LTR writing orientation for your language (RTL : Right to left , LTR : Left to right) .
5. Under `AlphabetFontMatrix` folder `>> Right click >> Create >> Localization >> AlphabetFontMatrix`
6. Set length according to your font variety . If you wish to use only 1 font for your whole project set length to 1 if more set it as you wish. 
(I'm assuming that you're using only one text font for your project.)
7. Set Latin font attribute to a font value which compatible for RTLTmpro asset . (typeof : TMP_FontAsset )
8. Set alphabet and its font in this matrix . (e.g. Latin Alphabet , MyriadPro-Regular SDF(TMP_FontAsset) ).
9. Under `Languages` folder `>> Right Click >> Create >> Localization >> Language` and set its Alphabet, Name , Icon and compatible system language text. (Repeat this step for as many language you would like to add in to your project.)


1. Right Click `Create>>Localization>>(Language Dependent Text/Sprite/Video)`
2. Set size for your language dependent item (I used Language dependent text for demonstration). Size indicates how many language that your text gonna be able to be translated .
3. Drag and drop your previously created language items froum your resources folder (If can't be found please proceed to the installation above)
4. Set content for your text .
5. Head to your `hierarchy >> right click >> UI >> Text - RTLTMP >> Click add component >> Language text` .
6. Set `Lang Dependent Text` attribute on your `Language text` (Which you have created on first step ) .
7. Press play and you are done !

## Demo Project

Demo project can be found under `Assets/Scenes` folder named `SampleScene`

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


# ENJOY !
