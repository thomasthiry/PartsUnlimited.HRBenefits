# Run with: Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Force; .\InstallDevVM.ps1


# Install choco
iwr -useb cin.st | iex

choco feature enable --name=allowGlobalConfirmation

choco install win-no-annoy # Removes many confirmation popups of a fresh windows install
choco install vscode
choco install git
choco install git-fork
choco install visualstudio2019community
choco install resharper
choco install ncrunch-vs2019
choco install cmdermini
choco install anydesk.install

mkdir C:\users\TddWorkshop\Dev\
cd C:\users\TddWorkshop\Dev\
git clone https://github.com/thomasthiry/PartsUnlimited.HRBenefits.git


# Install Resharper extension "Presentation Assistant"