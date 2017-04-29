#include <tools.h>
#include <QMessageBox>
#include <QProcess>
#include <QFileDialog>
#include <QObject>

void Tools::MsgBox(QString txt) {
    QMessageBox *msgBox = new QMessageBox(0);
    msgBox->setText(txt);
    msgBox->exec();
}

void Tools::launchApp(QString folder, QString file) {
    QProcess *process = new QProcess(0);
    QString str = folder + "/" + file;
    process->start(QDir::toNativeSeparators(str));
}

QString Tools::OpenExplorer(QString path) {
    QString dirLoc = QFileDialog::getExistingDirectory(0, QObject::tr("Open Directory"),
        path,
        QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);
    return QDir::toNativeSeparators(dirLoc);
}
