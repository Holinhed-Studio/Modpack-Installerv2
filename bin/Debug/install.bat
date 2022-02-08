@echo off
title "Modpack Installer System - Downloading FartsNCo..."
color C
echo WARNING: NOT RUNNING A BACKUP. ALL MOD RELATED CONTENT WILL BE DELETED. PRESS ANY KEY WITHIN 10 SECONDS TO CANCEL.
ping 1.1.1.1 -n 1 -w 10000 >nul
echo Synchronizing local cache with remote directory.
start wget -m -nH -d -A "*.jar" -T 3 -t 1 --no-parent "https://cdn.firehostredux.com/fartsncomc/mods/" >>output.log

