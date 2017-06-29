#ifndef TOOLS_H
#define TOOLS_H

#include <mainwindow.h>

class Tools
{
    public:
        void MsgBox(QString);
        void launchApp(QString, QString);
        QString OpenExplorer(QString);
        void zip(QString filename , QString zip_filename);
        void unZip(QString zip_filename , QString filename);
    private:

};

#endif
