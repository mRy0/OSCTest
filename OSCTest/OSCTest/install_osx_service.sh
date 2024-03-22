DST_DIR=~"/usr/local/Cellar/OSC-Service"


cd "$(dirname "$0")"

cp -R . "$DST_DIR"


cd "$"

sudo cp "localhost.osc-service.plist" "/Library/LaunchAgents"

cd "/Library/LaunchAgents"

 launchctl load localhost.osc-service.plist
 
 launchctl start localhost.osc-service