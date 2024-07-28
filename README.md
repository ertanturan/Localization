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

use `https://github.com/ertanturan/Unity-Localization.git` in unity package manager.
# Usage

## To Create a new language
1. Create a folder under Assets folder like this `Resources>>Data>>Localization>>Languages`
2. Head to `Languages` folder and right Click and choose `Create>>Localization>>Language`
3. Set Languae Orientation (LTR : Left to right and RTL: Righ to Left)
4. Set language font

## To create language-dependent text/sprite/video
1. Right Click `Create>>Localization>>(Language Dependent Text/Sprite/Video)`
2. Set size for your language dependent item (I used Language dependent text for demonstration). Size indicates how many language that your text gonna be able to be translated .
3. Drag and drop your previously created language items froum your resources folder (If can't be found please proceed to the installation above)
4. Set content for your text .
5. Head to your `hierarchy >> right click >> UI >> Text - RTLTMP >> Click add component >> Language text` .
6. Set `Lang Dependent Text` attribute on your `Language text` (Which you have created on first step ) .
7. Press play and you are done !

## Demo Project

Demo project can be found under `packages/package-directory/Scenes` folder named `LocalizationDemo`

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.


# ENJOY !
