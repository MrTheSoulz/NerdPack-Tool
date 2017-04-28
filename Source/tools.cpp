#include "tools.h"
#include <QMessageBox>
#include <QProcess>

/*
void Tools::MsgBox(QString txt) {
    QMessageBox *msgBox = new QMessageBox(this);
    msgBox->setText(text);
    msgBox->exec();
}

void Tools::launchApp(QString folder, QString file) {
    QProcess *process = new QProcess(this);
    QString str = folder + "/" + file;
    process->start(QDir::toNativeSeparators(str));
}

QString Tools::OpenExplorer(QString path) {
    QString dirLoc = QFileDialog::getExistingDirectory(this, tr("Open Directory"),
        path,
        QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    return dirLoc;
}
*/
