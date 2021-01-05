# Run with: 
# Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Force; iwr -useb https://raw.githubusercontent.com/thomasthiry/PartsUnlimited.HRBenefits/master/InstallDevTools.ps1 | iex


# Install choco
iwr -useb cin.st | iex

choco feature enable --name=allowGlobalConfirmation

choco install win-no-annoy # Removes many confirmation popups of a fresh windows install
choco install vscode
choco install git
choco install git-fork
choco install visualstudio2019community --package-parameters "--add Microsoft.VisualStudio.Workload.NetCoreTools --add Microsoft.VisualStudio.Workload.ManagedDesktop --add Microsoft.VisualStudio.Workload.NetWeb"
choco install resharper
choco install ncrunch-vs2019
choco install cmdermini
choco install anydesk.install

mkdir C:\users\TddWorkshop\Dev\
cd C:\users\TddWorkshop\Dev\
& "C:\Program Files\Git\bin\git.exe" clone https://github.com/thomasthiry/PartsUnlimited.HRBenefits.git

# Don't forget to install Resharper extension "Presentation Assistant"

# Set launch dev tools as a startup script
New-Item "C:\Users\TddWorkshop\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\LaunchDevTools.bat" -Force
Set-Content "C:\Users\TddWorkshop\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\LaunchDevTools.bat" "powershell C:\Users\TddWorkshop\Dev\PartsUnlimited.HRBenefits\LaunchDevTools.ps1"

# Set time to Brussels time
tzutil /s "Romance Standard Time"